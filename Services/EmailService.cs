using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var smtpConfig = _configuration.GetSection("Smtp");
        var smtpClient = new SmtpClient
        {
            Host = smtpConfig["Host"],
            Port = int.Parse(smtpConfig["Port"]),
            EnableSsl = bool.Parse(smtpConfig["EnableSSL"]),
            Credentials = new NetworkCredential(smtpConfig["UserName"], smtpConfig["Password"])
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtpConfig["UserName"]),
            Subject = subject,
            Body = message,
            IsBodyHtml = true
        };

        mailMessage.To.Add(toEmail);

        await smtpClient.SendMailAsync(mailMessage);
    }
}
