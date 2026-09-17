using System.ComponentModel.DataAnnotations;

namespace Sekolah.DTO
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";

        public bool RememberMe { get; set; }
    }
}
