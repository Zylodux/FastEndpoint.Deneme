using FastEndpoint.Deneme.Event_ornek2.Register;
using FastEndpoints;

namespace FastEndpoint.Deneme.Event_ornek2.Mail
{
    public class Handler : IEventHandler<UserRegisteredEvent>
    {
        public Task HandleAsync(UserRegisteredEvent ev, CancellationToken ct)
        {
            // SMTP veya SendGrid ile maili gönder
            return Task.CompletedTask;
        }
    }
}
