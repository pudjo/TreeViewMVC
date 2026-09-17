namespace Sekolah.DTO.ManajemenSekolah
{
    public class JenjangSekolahDto
    {
        public int ID { get; set; }
        public int TahunAjaranID { get; set; }

        // Nama jenjang (mis: "SMA")
        public string Nama { get; set; }

        // Nama sekolah (baru)
        public string NamaSekolah { get; set; }

        public List<TingkatSekolahDto> Tingkats { get; set; } = new();

    }
}
