using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BinaDaireYonetim.Models
{
    public class Bina
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Adres { get; set; }
        public int KatSayisi { get; set; }
        public DateTime InşaatTarihi { get; set; }
        public DateTime OlusturmaTarihi { get; set; } = DateTime.Now;

        // İlişki
        public ICollection<Daire> Daireler { get; set; } = new List<Daire>();
    }
}