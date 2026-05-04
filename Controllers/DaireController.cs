using BinaDaireYonetim.Data;
using BinaDaireYonetim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BinaDaireYonetim.Controllers
{
    [Authorize]
    public class DaireController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DaireController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Daire/Index/5 (Binaya ait daireleri listele)
        public async Task<IActionResult> Index(int binaId)
        {
            var bina = await _context.Binalar.FindAsync(binaId);
            if (bina == null)
                return NotFound();

            var daireler = await _context.Daireler
                .Where(d => d.BinaId == binaId)
                .Include(d => d.KatMalikleri)
                .Include(d => d.Kiracıları)
                .Include(d => d.Hesaplar)
                .ToListAsync();

            ViewData["BinaId"] = binaId;
            ViewData["BinaAdi"] = bina.Ad;
            return View(daireler);
        }

        // GET: Daire/Create/5
        public IActionResult Create(int binaId)
        {
            ViewData["BinaId"] = binaId;
            return View();
        }

        // POST: Daire/Create/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int binaId, [Bind("DaireNo,DaireTipi,Kat,PetekSayisi")] Daire daire)
        {
            if (binaId == 0)
            {
                ModelState.AddModelError("", "Bina seçilmedi!");
                ViewData["BinaId"] = binaId;
                return View(daire);
            }

            if (ModelState.IsValid)
            {
                daire.BinaId = binaId;
                _context.Add(daire);
                await _context.SaveChangesAsync();

                // Geçmiş kaydı oluştur
                var gecmis = new Gecmis
                {
                    DaireId = daire.Id,
                    Islem = $"Daire No {daire.DaireNo} oluşturuldu",
                    KullaniciAdi = User.Identity?.Name ?? "Sistem"
                };
                _context.Add(gecmis);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", new { binaId });
            }

            ViewData["BinaId"] = binaId;
            return View(daire);
        }

        // GET: Daire/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var daire = await _context.Daireler
                .Include(d => d.KatMalikleri)
                .Include(d => d.Kiracıları)
                .Include(d => d.Hesaplar)
                .Include(d => d.Notlar)
                .Include(d => d.Gecmisler)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (daire == null)
                return NotFound();

            return View(daire);
        }

        // POST: Daire/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DaireNo,DaireTipi,Kat,PetekSayisi,BinaId,OlusturmaTarihi")] Daire daire)
        {
            if (id != daire.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    daire.GuncellenmeTarihi = DateTime.Now;
                    _context.Update(daire);
                    await _context.SaveChangesAsync();

                    // Geçmiş kaydı oluştur
                    var gecmis = new Gecmis
                    {
                        DaireId = daire.Id,
                        Islem = "Daire Düzenlendi",
                        KullaniciAdi = User.Identity?.Name ?? "Sistem"
                    };
                    _context.Add(gecmis);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DaireExists(daire.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction("Edit", new { id });
            }
            return View(daire);
        }

        // GET: Daire/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var daire = await _context.Daireler.FindAsync(id);
            if (daire == null)
                return NotFound();

            return View(daire);
        }

        // POST: Daire/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var daire = await _context.Daireler.FindAsync(id);
            if (daire == null)
                return NotFound();

            var binaId = daire.BinaId;
            _context.Daireler.Remove(daire);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { binaId });
        }

        private bool DaireExists(int id)
        {
            return _context.Daireler.Any(e => e.Id == id);
        }
    }
}