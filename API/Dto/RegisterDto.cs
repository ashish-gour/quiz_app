using System.ComponentModel.DataAnnotations;

namespace API.Dto
{
    public class RegisterDto
    {
        [Required] public string? Username { get; set; }
        [Required] public string? FirstName { get; set; }
        [Required] public string? LastName { get; set; }
        [Required] public string? Organization { get; set; }
        [Required] public string? Gender { get; set; }
        [Required] public DateTime DateOfBirth { get; set; }
        [Required] public string? City { get; set; }
        [Required] public string? Country { get; set; }
        [Required]
        [StringLength(maximumLength: 16, MinimumLength = 4)]
        public string? Password { get; set; }
    }
}
