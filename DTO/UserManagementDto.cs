namespace Sekolah.DTO
{
    public class UserManagementDto
    {
        public string Id { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Address { get; set; } = "";
        public string Role { get; set; } = ""; // Kolom baru untuk role
        public string Status { get; set; } = "";
        public string CreatedAt { get; set; } = "";
    }
}
