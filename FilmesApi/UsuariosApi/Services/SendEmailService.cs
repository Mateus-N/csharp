using Newtonsoft.Json;
using System.Text;

namespace UsuariosApi.Services;

public class SendEmailService
{
    private readonly HttpClient httpClient;

    public SendEmailService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task SendToEmailAsync(string email,string subject, string title, string body)
    {
        string json = JsonConvert.SerializeObject(new
        {
            EmailTo = email,
            Subject = subject,
            Title = title,
            Body = body
        });

        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        var httpResponse = await httpClient.PostAsync("http://172.17.0.1:9000/EmailApp", httpContent);
        httpResponse.EnsureSuccessStatusCode();
    }
}
