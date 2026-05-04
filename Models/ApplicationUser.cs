using Microsoft.AspNetCore.Identity;

namespace BinaDaireYonetim.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? AdSoyad { get; set; }
    }
}
