namespace Sekolah.DTO.ManajemenSekolah
{
    public class TahunAjaranDto
    {
        public int ID { get; set; }
        public string Nama { get; set; }
        public DateTime TanggalMulai { get; set; }
        public DateTime TanggalAKhir { get; set; }

        public List<JenjangSekolahDto> Jenjangs { get; set; } = new();

    }
}
