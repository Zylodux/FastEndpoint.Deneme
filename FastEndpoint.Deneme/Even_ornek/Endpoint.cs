using FastEndpoints;

namespace FastEndpoint.Deneme.Even_ornek
{
    public class Endpoint: Endpoint<OrderRequest, OrderResponse>
    {
        public override void Configure()
        {
            Post("/api/orders/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(OrderRequest req, CancellationToken ct)
        {
            // 1. Siparişi DB'ye kaydet (Örnek ID: 500)
            int newOrderId = 500;
            decimal total = 1550.75m;

            // 2. EVENT YAYINLA: "Sipariş Oluşturuldu!"
            // Bu satır sayesinde sistemdeki diğer tüm parçalar haberdar olacak.
            await PublishAsync(new OrderCreatedEvent(newOrderId, total, req.CustomerEmail), Mode.WaitForAll, ct);

            await Send.OkAsync(new OrderResponse(newOrderId, "Siparişiniz alındı, işlemler başlıyor."), ct);
        }
    }
  
}
