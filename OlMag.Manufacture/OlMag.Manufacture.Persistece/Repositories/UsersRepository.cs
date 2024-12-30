using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OlMag.Manufacture.Core.Models;
using OlMag.Manufacture.Persistece.Entities;

namespace OlMag.Manufacture.Persistece.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ManufactureDbContext _context;
    private readonly IMapper _mapper;

    public UsersRepository(ManufactureDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task Add(User user)
    {
        var userEntity = new UserEntity()
        {
            Id = user.Id,
            UserName = user.UserName,
            PasswordHash = user.PasswordHash,
            Email = user.Email,
        };

        await _context.Users.AddAsync(userEntity);
        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByEmail(string email)
    {
        var userEntity = await _context.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(u=>u.Email == email) ?? throw new Exception("The password is incorrect or the user does not exist");

        return new User(userEntity.Id,userEntity.UserName,userEntity.PasswordHash,userEntity.Email);
        throw new NotImplementedException("return _mapper.Map<User>(userEntity);");
        //return _mapper.Map<User>(userEntity);
    }
}
