using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace Backend.Services.NotificationService
{
    public class EmailService:IEmailService
    {
        public async Task<string> SendEmail(string subject, string body)
        {
            string response = "";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("otha.kuhlman@ethereal.email"));
            email.To.Add(MailboxAddress.Parse("otha.kuhlman@ethereal.email"));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Text)
            {
                Text = body
            };
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("otha.kuhlman@ethereal.email", "tvdDh4bdRbvd6eJwYb");
            response=smtp.Send(email);
            smtp.Disconnect(true);
            return response;    
        }
    }
}
