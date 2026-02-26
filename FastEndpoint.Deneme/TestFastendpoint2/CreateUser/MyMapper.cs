using FastEndpoint.Deneme.Domain;
using FastEndpoints;

namespace FastEndpoint.Deneme.TestFastendpoint2.CreateUser
{
    public class MyMapper : Mapper<Request2, Response2, User>
    {
        // request -> entity (Kullanıcıdan gelen veriyi User nesnesine çevirir)
        public override User ToEntity(Request2 r)
        { return User.Create(r.Name, r.SurName, r.Age);
        }

        // db sonucundaki nesneyi response'a çevirir (Veritabanından gelen User nesnesini Response2 nesnesine çevirir)
        public override Response2 FromEntity(User e) => new Response2(
            e.user_id,
            e.Name + " " + e.SurName,
            e.Age
        );
    }
}
