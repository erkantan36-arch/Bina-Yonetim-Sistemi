using BinaDaireYonetim.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BinaDaireYonetim.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var toplamBina = await _context.Binalar.CountAsync();
            var toplamDaire = await _context.Daireler.CountAsync();

            // Aylık gelir ve gider: HesapIslem tablosundaki mevcut ay verileri
            var buAy = DateTime.Now.Month;
            var buYil = DateTime.Now.Year;

            var aylikGelir = await _context.HesapIslemler
                .Where(i => i.Tipi == "Giriş"
                            && i.Tarih.Month == buAy
                            && i.Tarih.Year == buYil)
                .SumAsync(i => (decimal?)i.Tutar) ?? 0m;

            var aylikGider = await _context.HesapIslemler
                .Where(i => i.Tipi == "Çıkış"
                            && i.Tarih.Month == buAy
                            && i.Tarih.Year == buYil)
                .SumAsync(i => (decimal?)i.Tutar) ?? 0m;

            // Bina bazlı aylık gelir ve gider özeti
            var binalar = await _context.Binalar
                .Include(b => b.Daireler)
                    .ThenInclude(d => d.Hesaplar)
                        .ThenInclude(h => h.Islemler)
                .ToListAsync();

            ViewBag.ToplamBina = toplamBina;
            ViewBag.ToplamDaire = toplamDaire;
            ViewBag.AylikGelir = aylikGelir;
            ViewBag.AylikGider = aylikGider;
            ViewBag.Binalar = binalar;
            ViewBag.BuAy = new DateTime(buYil, buAy, 1).ToString("MMMM yyyy", new System.Globalization.CultureInfo("tr-TR"));

            return View();
        }
    }
}
