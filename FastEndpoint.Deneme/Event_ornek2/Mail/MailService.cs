namespace Blog.Web.Infrastructure.Services.Email;

public interface IMailService
{
    Task SendEmailAsync(string to, string subject, string body);
}

public class MailService : IMailService
{
    public async Task SendEmailAsync(string to, string subject, string body)
    {
        // Buraya gerçek SMTP veya SendGrid kodlarını 1 kere yazarsın
        Console.WriteLine($"[SMTP] Alıcı: {to} | Konu: {subject} | İçerik: {body}");
        await Task.CompletedTask;
    }
}