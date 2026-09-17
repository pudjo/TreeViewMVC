namespace Sekolah.Models.ManajemenSekolah
{
    // Jenjang sekolah adalah tingkatan pendidikan yang ada di sekolah, misalnya SD, SMP, SMA, dll.
    public class JenjangSekolah
    {

        public int ID { get; set; }
        public int TahunAjaranID { get; set; }
        public TahunAjaran TahunAjaran { set; get; }

        // Nama jenjang (mis: "SMA")
        public string Nama { get; set; }

        // Nama sekolah (baru)
        public string NamaSekolah { get; set; }

    }
}
