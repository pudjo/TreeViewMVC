namespace Sekolah.Models.ManajemenSekolah
{
    public class TingkatSekolah
    {
        public int ID { get; set; }
        public int JenjangSekolahID { get; set; }
        public JenjangSekolah JenjangSekolah { set; get; }
        public string Nama { get; set; }
        public int TahunAjaranID { set; get; }
    }
}
