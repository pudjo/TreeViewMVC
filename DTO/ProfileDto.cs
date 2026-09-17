using System.ComponentModel.DataAnnotations;

namespace Sekolah.DTO
{
   
        public class ProfileDto
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; } = "";

            [Required]
            [Display(Name = "Nama Depan")]
            public string FirstName { get; set; } = "";

            [Required]
            [Display(Name = "Nama Belakang")]
            public string LastName { get; set; } = "";

            [Phone]
            [Display(Name = "Nomor Telepon")]
            public string? PhoneNumber { get; set; }

            [Display(Name = "Alamat")]
            public string? Address { get; set; }
        }
}
