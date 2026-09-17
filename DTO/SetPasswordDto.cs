using System.ComponentModel.DataAnnotations;

namespace Sekolah.DTO
{
    public class SetPasswordDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Kata sandi baru wajib diisi.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Kata sandi minimal harus 6 karakter.")]
        [DataType(DataType.Password)]
        [Display(Name = "Kata Sandi Baru")]
        public string NewPassword { get; set; } = string.Empty;

        [Required(ErrorMessage = "Konfirmasi kata sandi wajib diisi.")]
        [DataType(DataType.Password)]
        [Display(Name = "Konfirmasi Kata Sandi Baru")]
        [Compare("NewPassword", ErrorMessage = "Konfirmasi kata sandi tidak cocok.")]
        public string ConfirmNewPassword { get; set; } = string.Empty;
    }
}
