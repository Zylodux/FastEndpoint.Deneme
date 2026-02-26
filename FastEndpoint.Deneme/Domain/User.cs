namespace FastEndpoint.Deneme.Domain
{
    public class User
    {
        public int user_id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int Age  { get; set; }
        

        private User() { }
        public static User Create(string name, string surName,int age)
        {
            // Kurumsal kurallar 
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("İsim boş olamaz!");
            if (age < 18) throw new Exception("18 yaşından küçükler kayıt olamaz!");

            return new User
            {
                Name = name,
                SurName = surName,
                Age = age,
                // Şifreleme işlemi
               // PasswordHash = BCrypt.Net.BCrypt.HashPassword(rawPassword)
            };
        }
    }
}
