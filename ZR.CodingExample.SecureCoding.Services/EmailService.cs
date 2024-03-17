
using System.Net.Mail;
namespace ZR.CodingExample.SecureCoding.Services;
public static class EmailService
{
    public static void SendConfirmationEmail(string email)
    {
        string subject = "Confirmation Email";
        string body = "Please confirm your email address.";

        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("your-email@example.com");
        mailMessage.To.Add(email);
        mailMessage.Subject = subject;
        mailMessage.Body = body;

        SmtpClient smtpClient = new SmtpClient("your-smtp-server");
        smtpClient.Send(mailMessage);
    }
}
