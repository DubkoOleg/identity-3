﻿using OlMag.Manufacture.Api.Contracts.Users;
using OlMag.Manufacture.Application.Services;

namespace OlMag_Manufacture.Api.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app) 
        {
            app.MapPost("register", Register);
            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(RegisterUserRequest request, UserService usersService)
        {
            await usersService.Register(request.UserName, request.Email, request.Password);

            return Results.Ok();
        }
        private static async Task<IResult> Login(LoginUserRequest request, UserService usersService)
        {
            var token = await usersService.Login(request.Email, request.Password);
            return Results.Ok(token);
        }
    }
}
