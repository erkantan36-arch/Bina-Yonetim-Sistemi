namespace BinaDaireYonetim.Models
{
    public class HesapIslem
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; } = DateTime.Now;
        public string Tipi { get; set; } // Giriş, Çıkış
        public decimal Tutar { get; set; }
        public string Aciklama { get; set; }

        // Foreign Key
        public int HesapId { get; set; }
        public Hesap Hesap { get; set; }
    }
}