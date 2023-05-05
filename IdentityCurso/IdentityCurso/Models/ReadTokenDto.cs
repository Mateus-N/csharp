namespace IdentityCurso.Models;

public class ReadTokenDto
{
    public string Token { get; set; }

    public ReadTokenDto(string token)
    {
        Token = token;
    }
}
