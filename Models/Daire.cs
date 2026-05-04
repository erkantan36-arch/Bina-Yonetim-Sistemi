namespace BinaDaireYonetim.Models
{
    public class Daire
    {
        public int Id { get; set; }
        public string DaireNo { get; set; }
        public string DaireTipi { get; set; }
        public int Kat { get; set; }
        public int PetekSayisi { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;
        public DateTime? GuncellenmeTarihi { get; set; }

        // Foreign Key - Burası kalabilir, sayısal değerdir.
        public int BinaId { get; set; }

        // Navigation Property - SORU İŞARETİ (?) EKLEDİK
        public Bina? Bina { get; set; }

        // İlişkiler - Bunlara da ekleyebilirsin veya sadece Bina'yı düzeltsen de yeter.
        public ICollection<KatMaliki>? KatMalikleri { get; set; } = new List<KatMaliki>();
        public ICollection<Kiracı>? Kiracıları { get; set; } = new List<Kiracı>();
        public ICollection<Hesap>? Hesaplar { get; set; } = new List<Hesap>();
        public ICollection<Not>? Notlar { get; set; } = new List<Not>();
        public ICollection<Gecmis>? Gecmisler { get; set; } = new List<Gecmis>();
    }
}