namespace OlMag.Manufacture.Infrastructure;

public class PasswordHasher : Application.Interfaces.Auth.IPasswordHasher
{
    public string Generate(string password) => BCrypt.Net.BCrypt.EnhancedHashPassword(password);

    public bool Verify(string password, string hashedPassword) => BCrypt.Net.BCrypt.EnhancedVerify(password, hashedPassword);
}
