using FastEndpoints;

namespace FastEndpoint.Deneme.Test
{
    public class EndPoint : Endpoint<Request, Response>
    {
        public override void Configure()
        {
            Post("/api/user/create");
            AllowAnonymous();
       
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
           
            if (req.Age < 18) AddError(a=> a.Age, "yaşınız 18 den küçük");
            ThrowIfAnyErrors();
            await Send.OkAsync(new()
            {
                FullName = req.FirstName + " " + req.LastName,
                IsOver18 = req.Age > 18
                
            });
        }
    }

}
