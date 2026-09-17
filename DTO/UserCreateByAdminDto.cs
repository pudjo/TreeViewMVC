using Sekolah.Models;
using System.ComponentModel.DataAnnotations;

namespace Sekolah.DTO
{
    public class UserCreateByAdminDto
    {
        [Required(ErrorMessage = "Nama depan wajib diisi.")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nama belakang wajib diisi.")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email wajib diisi.")]
        [EmailAddress(ErrorMessage = "Format email tidak valid.")]
        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }

        // Role yang ditentukan oleh Admin (misal: "User", "Staff", dll)
        [Required(ErrorMessage = "Role wajib dipilih.")]
        public string SelectedRole { get; set; } = "User";

        // Status awal akun, defaultnya PendingPassword karena didaftarkan admin tanpa password
        public UserStatus Status { get; set; } = UserStatus.PendingPassword;
    }
}
