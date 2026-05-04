namespace BinaDaireYonetim.Models
{
    public class Not
    {
        public int Id { get; set; }
        public string Icerik { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellenmeTarihi { get; set; }
        public string OlusturanKullanici { get; set; }
        public bool Hatirlatma { get; set; } = false;
        public DateTime? HatirlatmaTarihi { get; set; }

        // Foreign Key
        public int DaireId { get; set; }
        public Daire Daire { get; set; }
    }
}