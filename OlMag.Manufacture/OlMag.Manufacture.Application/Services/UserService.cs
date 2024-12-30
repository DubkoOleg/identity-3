using OlMag.Manufacture.Application.Interfaces.Auth;
using OlMag.Manufacture.Core.Models;
using OlMag.Manufacture.Persistece.Repositories;

namespace OlMag.Manufacture.Application.Services;

public class UserService
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;
    private readonly IUsersRepository _usersRepository;

    public UserService(
        IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        IJwtProvider jwtProvider)
    {
        //throw new NotImplementedException("IUsersRepository");
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
        _usersRepository = usersRepository;
    }

    public async Task Register(string userName, string email, string password)
    {
        var hashedPassword = _passwordHasher.Generate(password);

        var user = User.Create(userName, hashedPassword, email);
        await _usersRepository.Add(user);
    }

    public async Task<string> Login(string email, string password)
    {
        var user = await _usersRepository.GetByEmail(email);

        var result = _passwordHasher.Verify(password, user.PasswordHash);
        if (result == false) { 
            throw new NotImplementedException("Return error failed login");
        }

        var token = _jwtProvider.GenerateToken(user);
        return token;
    }
}
