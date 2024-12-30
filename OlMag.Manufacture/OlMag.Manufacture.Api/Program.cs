using Microsoft.EntityFrameworkCore;
using OlMag.Manufacture.Application.Interfaces.Auth;
using OlMag.Manufacture.Application.Services;
using OlMag.Manufacture.DataAccess;
using OlMag.Manufacture.Infrastructure;
using OlMag.Manufacture.Persistece;
using OlMag.Manufacture.Persistece.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var configuration = builder.Configuration;

services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));

/*services.AddDbContext<LearningDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(LearningDbContext)));
});*/
services.AddDbContext<ManufactureDbContext>(options =>
{
    options.UseNpgsql(configuration.GetConnectionString(nameof(ManufactureDbContext)));
});

builder.Services.AddScoped<IUsersRepository, UsersRepository>();

builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

services.AddAutoMapper(typeof(DataBaseMapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.AddMappedEndpoints();

app.UseAuthorization();

app.MapControllers();

app.Run();
