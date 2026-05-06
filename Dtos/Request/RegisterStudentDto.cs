using System.ComponentModel.DataAnnotations;

namespace SEM2WebAPI.Dtos.Request
{
    public class RegisterStudentDto
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required, StringLength(50)]
        public string LastName { get; set; } = null!;

        [Required, EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required, StringLength(int.MaxValue, MinimumLength = 8)]
        public string Password { get; set; } = null!;
    }
}
