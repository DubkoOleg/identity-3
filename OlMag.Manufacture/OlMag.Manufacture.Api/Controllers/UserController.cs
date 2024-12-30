using Microsoft.AspNetCore.Mvc;
using OlMag.Manufacture.Api.Contracts.Users;
using OlMag.Manufacture.Application.Services;

namespace OlMag.Manufacture.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _usersService;
        private readonly ILogger<UserController> _logger;

        public UserController(UserService usersService, ILogger<UserController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }
        
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            await _usersService.Register(request.UserName, request.Email, request.Password);
            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            var token = await _usersService.Login(request.Email, request.Password);
            return Ok(token);
        }
    }
}
