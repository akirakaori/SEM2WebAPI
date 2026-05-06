using System.ComponentModel.DataAnnotations;

namespace SEM2WebAPI.Dtos.Request
{
    public class LoginDto
    {
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}