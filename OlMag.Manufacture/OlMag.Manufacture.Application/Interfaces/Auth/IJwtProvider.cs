using OlMag.Manufacture.Core.Models;

namespace OlMag.Manufacture.Application.Interfaces.Auth
{
    public interface IJwtProvider
    {
         string GenerateToken(User user);
    }
}
