using BinaDaireYonetim.Data;
using BinaDaireYonetim.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BinaDaireYonetim.Controllers
{
    [Authorize]
    public class BinaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BinaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bina
        public async Task<IActionResult> Index()
        {
            var binalar = await _context.Binalar.Include(b => b.Daireler).ToListAsync();
            return View(binalar);
        }

        // GET: Bina/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var bina = await _context.Binalar
                .Include(b => b.Daireler)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bina == null)
                return NotFound();

            return View(bina);
        }

        // GET: Bina/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bina/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Ad,Adres,KatSayisi,InşaatTarihi")] Bina bina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bina);
        }

        // GET: Bina/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var bina = await _context.Binalar.FindAsync(id);
            if (bina == null)
                return NotFound();

            return View(bina);
        }

        // POST: Bina/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ad,Adres,KatSayisi,InşaatTarihi,OlusturmaTarihi")] Bina bina)
        {
            if (id != bina.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinaExists(bina.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bina);
        }

        // GET: Bina/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var bina = await _context.Binalar
                .Include(b => b.Daireler)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bina == null)
                return NotFound();

            return View(bina);
        }

        // POST: Bina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bina = await _context.Binalar
                .Include(b => b.Daireler)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (bina == null)
                return NotFound();

            // Eğer daireler varsa silme işlemini iptal et
            if (bina.Daireler.Any())
            {
                ModelState.AddModelError("", "Binada daireler bulunmaktadır. Önce daireleri silmelisiniz.");
                return View(bina);
            }

            _context.Binalar.Remove(bina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinaExists(int id)
        {
            return _context.Binalar.Any(e => e.Id == id);
        }
    }
}