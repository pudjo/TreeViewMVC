namespace Sekolah.Models.ManajemenSekolah
{
    public class Ruangan
    {
        public int ID { set; get; }
        public string Nama { set; get; }

        public int GedungID { set; get; }
        public GedungSekolah Gedung { set; get; }
        public int Kapasitas { set; get; }


    }
}
