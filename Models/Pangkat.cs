namespace Sekolah.Models
{
    public class Pangkat
    {
        public int Id { get; set; }
        public string Code { get; set; } =string.Empty;

        public int  GolonganID { set; get; } 
        public Golongan Golongan { set; get; } 
        public string Name { set; get; }=string.Empty;

    }
}
