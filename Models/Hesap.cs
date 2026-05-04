namespace BinaDaireYonetim.Models
{
    public class Hesap
    {
        public int Id { get; set; }
        public string HesapAdi { get; set; }
        public string HesapTipi { get; set; } // Aidat, Elektrik, Su, vb.
        public decimal Bakiye { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

        // Foreign Key
        public int DaireId { get; set; }
        public Daire Daire { get; set; }

        // İlişkiler
        public ICollection<HesapIslem> Islemler { get; set; } = new List<HesapIslem>();
    }
}