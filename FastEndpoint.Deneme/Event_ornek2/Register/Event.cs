using FastEndpoints;

namespace FastEndpoint.Deneme.Event_ornek2.Register
{
    // MODELLER
    public record SaveUserCommand(string Email, string Password) : ICommand<int>;
    public record RegisterRequest(string Email, string Password);
    public record RegisterResponse(int UserId, string Message);
    public record UserRegisteredEvent(int UserId, string Email) : IEvent;

    // UZMAN (Kayıt işini yapan)
    public class CommonHandler : ICommandHandler<SaveUserCommand, int>
    {
        public async Task<int> ExecuteAsync(SaveUserCommand cmd, CancellationToken ct)
        {
            Console.WriteLine($"[DB] {cmd.Email} kaydedildi.");
            return 101;
        }
    }

    // GİRİŞ KAPISI
    public class RegisterEndpoint : Endpoint<RegisterRequest, RegisterResponse>
    {
        public override void Configure() { Post("/api/auth/register"); AllowAnonymous(); }

        public override async Task HandleAsync(RegisterRequest req, CancellationToken ct)
        {
            // Önce kayıt et
            var userId = await new SaveUserCommand(req.Email, req.Password).ExecuteAsync(ct);
            // Sonra "Kayıt bitti" diye bağır (Event fırlat)
            await PublishAsync(new UserRegisteredEvent(userId, req.Email), Mode.WaitForAll, ct);

            await Send.OkAsync(new RegisterResponse(userId, "Başarılı"));
        }
    }
}
