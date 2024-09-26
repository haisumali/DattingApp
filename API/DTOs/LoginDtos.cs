using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class LoginDtos
    {
        [Required]
        public required string UserName { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
