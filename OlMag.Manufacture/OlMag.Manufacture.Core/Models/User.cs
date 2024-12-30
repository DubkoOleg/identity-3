namespace OlMag.Manufacture.Core.Models
{
    public class User
    {
        public User(Guid id, string userName, string passwordHash, string email)
        {
            Id = id;
            UserName = userName;
            PasswordHash = passwordHash;
            Email = email;
        }

        public Guid Id { get; set; }
        public string UserName { get; }
        public string PasswordHash { get; }
        public string Email { get; }

        public static User Create(string userName, string passwordHash, string email, Guid? id = null) =>
            new User(id ?? Guid.NewGuid(), userName, passwordHash, email);
    }
}
