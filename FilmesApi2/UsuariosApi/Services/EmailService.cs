using MailKit.Net.Smtp;
using MimeKit;
using UsuariosApi.Models;

namespace UsuariosApi.Services;

public class EmailService
{
	private IConfiguration configuration;

	public EmailService(IConfiguration configuration)
	{
		this.configuration = configuration;
	}

	public void EnviarEmail(string?[] destinatario, string assunto, int usuarioId, string code)
	{
		Mensagem mensagem = new Mensagem(destinatario, assunto, usuarioId, code);
		
		MimeMessage mensagemDeEmail = CriaCorpoDeEmail(mensagem);
		Enviar(mensagemDeEmail);
	}

	private void Enviar(MimeMessage mensagemDeEmail)
	{
		using (var client = new SmtpClient())
		{
			try
			{
				client.ServerCertificateValidationCallback = (s, c, h, e) => true;
				client.Connect(
					configuration.GetValue<string>("EmailSettings:SmtpServer"),
					configuration.GetValue<int>("EmailSettings:Port"), true);
				
				client.AuthenticationMechanisms.Remove("XOUATH2");
				
				client.Authenticate(
					configuration.GetValue<string>("EmailSettings:From"),
					configuration.GetValue<string>("EmailSettings:Password"));
				
				client.Send(mensagemDeEmail);
			}
			catch
			{
				throw;
			}
			finally
			{
				client.Disconnect(true);
				client.Dispose();
			}
		}
	}

	private MimeMessage CriaCorpoDeEmail(Mensagem mensagem)
	{
		MimeMessage mensagemDeEmail = new MimeMessage();
		mensagemDeEmail.From.Add (new MailboxAddress (configuration.GetValue<string>("EmailSettings:From")));
		mensagemDeEmail.To.AddRange(mensagem.Destinatario);
		mensagemDeEmail.Subject = mensagem.Assunto;
		mensagemDeEmail.Body = new TextPart(MimeKit.Text.TextFormat.Text)
		{
			Text = mensagem.Conteudo
		};

		return mensagemDeEmail;
	}
}