namespace Sekolah.DTO.ManajemenSekolah
{
    public class TingkatSekolahDto
    {
        public int ID { get; set; }
        public int JenjangSekolahID { get; set; }
        public int TahunAjaranID { get; set; }
        public string Nama { get; set; }

        public List<RombonganBelajarDto> Rombongans { get; set; } = new();
    }
}
