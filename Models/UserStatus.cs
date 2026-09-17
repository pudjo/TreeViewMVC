namespace Sekolah.Models
{
    public enum UserStatus
    {
        PendingPassword = 0, // Didaftarkan Admin, belum set password
        Active = 1,          // Akun aktif & bisa transaksi
        Inactive = 2,        // Dinonaktifkan sementara
        SoftDeleted = 3      // Dihapus secara sistem (arsip)
    }
}
