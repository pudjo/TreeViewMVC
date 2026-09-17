namespace Sekolah.Models
{
    public class Sekolah
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Nama { get; set; } = string.Empty;
        public string Alamat { get; set; } = string.Empty;
        public int Swasta { get; set; }

        public string Akreditasi { get; set; } = string.Empty;



        public string Ibukota { get; set; } = string.Empty;
        public string? LogoPictureUrl { get; set; } = string.Empty;
    }
}
