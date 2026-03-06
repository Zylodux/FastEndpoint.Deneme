using FastEndpoints;

namespace FastEndpoint.Deneme.Even_ornek
{
    // Event: Sipariş oluşturuldu haberi (IEvent sayesinde her yerden Publish edilebilir)
    public record OrderCreatedEvent(int OrderId, decimal TotalAmount, string CustomerEmail) : IEvent;

    // Command: Fatura kesme emri (ICommand sayesinde her yerden çağrılabilir)
    public record CreateInvoiceCommand(int OrderId, decimal Amount) : ICommand<bool>;

    // API Request/Response
    public record OrderRequest(string CustomerEmail, List<int> ProductIds);
    public record OrderResponse(int OrderId, string Message);
}
