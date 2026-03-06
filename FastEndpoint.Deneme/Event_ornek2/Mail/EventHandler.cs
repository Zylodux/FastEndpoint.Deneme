namespace Blog.Web.Features.Notifications.Email;

using Blog.Web.Infrastructure.Services.Email;

//using Auth.Register; // Haberi tanıması için
using FastEndpoint.Deneme.Event_ornek2.Register;
using FastEndpoints;
//using Infrastructure.Services.Email; // Uzmanı tanıması için

public class WelcomeMailHandler(IMailService mailService) : IEventHandler<UserRegisteredEvent>
{
    private readonly IMailService _mailService = mailService;

    // Uzmanı (MailService) Dependency Injection ile içeri alıyoruz  

    public async Task HandleAsync(UserRegisteredEvent ev, CancellationToken ct)
    {
        // Haberi (Event) aldık, uzmanı (Service) çalıştırıyoruz.
        await _mailService.SendEmailAsync(
            to: ev.Email,
            subject: "Hoş Geldin!",
            body: "Sitemize kayıt olduğun için teşekkürler."
        );
    }
}
//yarın şifremi unuttum dinleyicisi
public class ResetPasswordMailHandler(IMailService mailService) : IEventHandler<ResetPasswordTokenGeneratedEvent>
{
    private readonly IMailService _mailService=mailService;

    public async Task HandleAsync(ResetPasswordTokenGeneratedEvent ev, CancellationToken ct)
    {
        // Aynı uzman, farklı görev!
        await _mailService.SendEmailAsync(ev.Email, "Şifre Sıfırlama", $"Token: {ev.Token}");
    }
}