namespace Backend.Services.NotificationService
{
    public interface IEmailService
    {
        Task SendEmail(string subject, string body);
    }
}
