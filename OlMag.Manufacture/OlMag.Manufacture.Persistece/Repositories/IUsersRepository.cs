using OlMag.Manufacture.Core.Models;

namespace OlMag.Manufacture.Persistece.Repositories
{
    public interface IUsersRepository
    {
        Task Add(User user);
        Task<User> GetByEmail(string email);
    }
}