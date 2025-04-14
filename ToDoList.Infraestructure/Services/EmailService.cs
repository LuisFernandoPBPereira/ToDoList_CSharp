using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using ToDoList.Application.Services;

namespace ToDoList.Infraestructure.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool Send(string email, string subject, string message)
    {
        try
        {
            string host = _configuration["SMTP:Host"];
            string nome = _configuration["SMTP:Nome"];
            string username = _configuration["SMTP:UserName"];
            string password = _configuration["SMTP:Password"];
            int.TryParse(_configuration["SMTP:Port"], out int port);

            MailMessage mailMessage = new MailMessage()
            {
                From = new MailAddress(username, nome),
            };

            mailMessage.To.Add(email);
            mailMessage.Subject = subject;
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;

            using (SmtpClient smtpClient = new SmtpClient(host, port))
            {
                smtpClient.Credentials = new NetworkCredential(username, password);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mailMessage);
                return true;
            }

        }
        catch (Exception)
        {
            return false;
        }
    }
}
