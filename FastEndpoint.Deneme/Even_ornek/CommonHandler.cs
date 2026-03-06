using FastEndpoints;

namespace FastEndpoint.Deneme.Even_ornek
{
    public class CommonHandler : ICommandHandler<CreateInvoiceCommand, bool>
    {
        // Buraya IEmailService veya DbContext enjekte edebilirsin
        public async Task<bool> ExecuteAsync(CreateInvoiceCommand cmd, CancellationToken ct)
        {
            // 1. Fatura hesaplamalarını yap
            // 2. PDF oluştur veya E-Fatura sistemine gönder
            Console.WriteLine($"[LOG] {cmd.OrderId} nolu sipariş için {cmd.Amount} TL tutarında fatura kesildi.");
            return true;
        }
    }
}
