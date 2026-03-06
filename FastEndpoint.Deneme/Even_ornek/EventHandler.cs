using FastEndpoints;

namespace FastEndpoint.Deneme.Even_ornek
{
    // FATURA KESİCİ: Sipariş olunca otomatik fatura komutunu çalıştırır  
    public class EventHandler: IEventHandler<OrderCreatedEvent>
    { 
        public async Task HandleAsync(OrderCreatedEvent ev, CancellationToken ct)
        {
            // Command'i çağırıyoruz (Hibrit yapı: Event içinden Command tetikleme)
            await new CreateInvoiceCommand(ev.OrderId, ev.TotalAmount).ExecuteAsync(ct);
        }
    }   

    // MAİLCİ: Sipariş olunca kullanıcıya mail atar
    public class OrderEmailHandler : IEventHandler<OrderCreatedEvent>
    {
        public async Task HandleAsync(OrderCreatedEvent ev, CancellationToken ct)
        {
            Console.WriteLine($"[MAIL] {ev.CustomerEmail} adresine sipariş onayı gönderildi.");
            await Task.CompletedTask;
        }
    }
}
