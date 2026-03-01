using FastEndpoints;

namespace FastEndpoint.Deneme.EventMantığı
{
    //Kullanıcı kayıt oluyor (Endpoint) ve event ekleyelim 
    public record RegisterEvent(int UserId) : IEvent;
    public record Request(string Email, string Password);
    public record Result(string Token);
    public class EndPoint : Endpoint<Request, Result>
    {
        public override void Configure()
        {
            Post("/api/account/create");
            AllowAnonymous();

        }
        //Kullanıcı kayıt oluyor (Endpoint),
        //kayıt bitince bir haber uçuruyoruz (Event),
        //bu haberi duyan bir sistem de gidip kullanıcıya otomatik rol atıyor (Handler & Command).

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            //email kayıtlı mı kontrol et yoksa hata döndür 
            // Request'i mapleve veritabanına kayıt et               
            //veri tabanından gelen yeni kaydı ile yeni token oluştur   istiyosan token oluşturmayı mapleyebilirsin resulta 
            //haber ver diğer servislere
            int id = 1;
            //diğer servicelere haber veriyoruz eventi yayınla
            await PublishAsync(new RegisterEvent(id), Mode.WaitForAll, ct);
            //result döndür 


            string Token = "123456";
            await Send.OkAsync(new Result(Token), ct);
        }
    }

    //Yol -1- eventi işleyecek olan handler 
    public class EventConsumers : IEventHandler<RegisterEvent>
    {
        public async Task HandleAsync(RegisterEvent ev, CancellationToken ct)
        {

            //burda istiyosak rolü db ye kayıt edebiliriz veya  rolü burdan vermek isteyiop hemde rolü endpointen vermek istersek şöyle bi yol izleyebiliriz
            Console.WriteLine($"{ev.UserId} için standart rol tanımlandı.");
        }
    }
    //Yol -2- Rol atama işlemi için bir command handler yazalım böylelikle hem endpointten hemde evet handelerdan kullanabiliriz.
    //öcne bizim bi rol atama nesne sınıfımız  olsun   
    public record AssignRoleCommand(int UserId, string RoleName) : ICommand<string>;

    public class AssignRoleHandler : ICommandHandler<AssignRoleCommand, string>
    {
        // Buraya DbContext enjekte edebilirsin
        public async Task<string> ExecuteAsync(AssignRoleCommand cmd, CancellationToken ct)
        {
            // VERİTABANI İŞLEMİ SADECE BURADA yapılcak 
            // _db.UserRoles.Add(new { cmd.UserId, cmd.RoleName });
            return $"{cmd.UserId} ID'li kullanıcıya '{cmd.RoleName}' rolü başarıyla verildi.";
        }
    }

    // 3. EVENT CONSUMER  sınıfı register event duyunca otomatik role ataması gerçekleşicek burda commmon handlera yönlendiriyoruz
    public class EventConsumer : IEventHandler<RegisterEvent>
    {
        public async Task HandleAsync(RegisterEvent ev, CancellationToken ct)
        {
            // Kayıt haberi gelince otomatik 'StandardUser' rolü emri veriyoruz
            await new AssignRoleCommand(ev.UserId, "StandardUser").ExecuteAsync(ct);
        }
    }

    // 4. KAYIT ENDPOINT (Asıl Giriş Kapısı)
    public class RegisterEndpoint : Endpoint<Request, Result>
    {
        public override void Configure()
        {
            Post("/api/account/create");
            AllowAnonymous();
        }

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            
            int yeniUserId = 1;
            //burda istersek db den gelen role tablosundaki rolleri ilgil kull verebilirriz yada aşşağıdaki gibi  standart rolü verebiliriz
            await new AssignRoleCommand(yeniUserId, "BasicUser").ExecuteAsync(ct);        

            await Send.OkAsync(new Result("Token_123456"), ct);
        }
    }


}
