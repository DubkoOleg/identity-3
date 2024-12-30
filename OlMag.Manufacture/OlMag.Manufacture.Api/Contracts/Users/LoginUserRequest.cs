using System.ComponentModel.DataAnnotations;

namespace OlMag.Manufacture.Api.Contracts.Users
{
    public record LoginUserRequest(
        [Required] string Email, 
        [Required] string Password);
}
