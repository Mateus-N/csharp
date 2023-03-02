using EmailApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmailApp.Controllers;

[ApiController]
[Route("[controller]")]
public class EmailAppController : ControllerBase
{
    private readonly IEmailSender emailSender;

    public EmailAppController(IEmailSender emailSender)
    {
        this.emailSender = emailSender;
    }

    [HttpGet]
    public async Task Get()
    {
        var message = new Message(new string[] { "mateusnunes620@gmail.com" }, "test email", "Email Async");
        await emailSender.SendEmailAsync(message);
    }
}
