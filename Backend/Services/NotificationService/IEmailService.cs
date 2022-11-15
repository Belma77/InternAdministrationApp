namespace Backend.Services.NotificationService
{
    public interface IEmailService
    {
        Task<string> SendEmail(string subject, string body);
    }
}
