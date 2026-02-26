using FastEndpoints;

namespace FastEndpoint.Deneme.TestFastendpoint2.CreateUser
{
    public class EndPoint : Endpoint<Request2, Response2,MyMapper>
    {


        public override void Configure()
        {
            Post("/api/user/test2");
            AllowAnonymous();

        }

        public override async Task HandleAsync(Request2 req, CancellationToken ct)
        {

            // 1. Request'i User nesnesine çeviriyoruz mapleme 
            var newUser = Map.ToEntity(req);

            // Buraya veritabanına ekleme kodu yazılabilir
            newUser.user_id = 1; // Şimdilik manuel bi id atıyorum


            // burda mapper bizim için Response2 nesnesi oluşturacak ve dolduracak
            var response = Map.FromEntity(newUser);

            await Send.OkAsync(response, ct);
        }
    }
}
