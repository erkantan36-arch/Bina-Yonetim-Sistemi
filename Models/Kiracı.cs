namespace BinaDaireYonetim.Models
{
    public class Kiracı
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public DateTime BaslamaTarihi { get; set; } = DateTime.Now;
        public DateTime? BitisTarihi { get; set; }
        public bool AktifMi { get; set; } = true;

        // Foreign Key
        public int DaireId { get; set; }
        public Daire Daire { get; set; }
    }
}