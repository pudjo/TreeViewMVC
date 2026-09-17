using Microsoft.Identity.Client;

namespace Sekolah.Models.ManajemenSekolah
{
    public class RombonganBelajar
    {
        public int ID { get; set; }
        public int JenjangSekolahID { get; set; }
        public string Nama { get; set; }
        public int TingkatSekolahID { get; set; }
        public int JurusanID { set; get; }
        public Jurusan Jurusan{ set; get; }

        public TingkatSekolah TingkatSekolah { get; set; }
        
        public int TahunAjaranID { set; get; }
    }
}
