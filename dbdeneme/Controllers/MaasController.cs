using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dbdeneme.Data;
using dbdeneme.Models;

namespace dbdeneme.Controllers
{
    public class MaasController : Controller
    {
        private readonly AppDbContext _context;

        public MaasController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var maaslar = await _context.Maaslar.Include(m => m.Personel).ToListAsync();
            return View(maaslar);
        }

        public IActionResult Create()
        {
            ViewBag.Personeller = _context.Personeller.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Maas maas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(maas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Personeller = _context.Personeller.ToList();
            return View(maas);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var maas = await _context.Maaslar.Include(m => m.Personel).FirstOrDefaultAsync(m => m.Id == id);
            if (maas == null)
                return NotFound();

            return View(maas);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var maas = await _context.Maaslar.FindAsync(id);
            if (maas != null)
            {
                _context.Maaslar.Remove(maas);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
