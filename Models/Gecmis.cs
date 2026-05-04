namespace BinaDaireYonetim.Models
{
    public class Gecmis
    {
        public int Id { get; set; }
        public string Islem { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string KullaniciAdi { get; set; }

        // Foreign Key
        public int DaireId { get; set; }
        public Daire Daire { get; set; }
    }
}