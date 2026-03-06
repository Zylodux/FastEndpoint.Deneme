using FastEndpoint.Deneme.Event_ornek2.Register; // Haberi duymak için referans lazım
using FastEndpoints;

namespace FastEndpoint.Deneme.Event_ornek2.Mail;

// EVENT HANDLER BURADA! 
// Register klasöründe değil, Mail klasöründe çünkü maili bu gönderiyor.
public class MailEventHandler : IEventHandler<UserRegisteredEvent>
{
    public async Task HandleAsync(UserRegisteredEvent ev, CancellationToken ct)
    {
        // Register modülünden gelen UserRegisteredEvent paketini açıyor
        Console.WriteLine($"[MAIL] {ev.Email} adresine hoş geldin maili gitti.");
        await Task.CompletedTask;
    }
}
