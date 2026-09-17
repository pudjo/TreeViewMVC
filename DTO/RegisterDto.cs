using Sekolah.Models;
using System.ComponentModel.DataAnnotations;

namespace Sekolah.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "First Name wajib diisi.")]
        [MaxLength(100, ErrorMessage = "First Name maksimal 100 karakter.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name wajib diisi.")]
        [MaxLength(100, ErrorMessage = "Last Name maksimal 100 karakter.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email wajib diisi.")]
        [EmailAddress(ErrorMessage = "Format email tidak valid.")]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Format nomor telepon tidak valid.")]
        [MaxLength(20)]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Alamat wajib diisi.")]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password wajib diisi.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password minimal {2} dan maksimal {1} karakter.")]
        public string? Password { get; set; } = string.Empty;
        public bool IsAdminRegistration { get; set; } = false;
        [Required(ErrorMessage = "Konfirmasi password wajib diisi.")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Password dan Konfirmasi Password tidak cocok.")]
        public string? ConfirmPassword { get; set; } = string.Empty;
        public UserStatus Status { get; set; } = UserStatus.Active;
    }
}
