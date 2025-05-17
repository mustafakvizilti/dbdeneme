using Microsoft.AspNetCore.Mvc;
using dbdeneme.Models;
using Microsoft.EntityFrameworkCore;
using dbdeneme.Data;

namespace dbdeneme.Controllers
{
    public class PozisyonController : Controller
    {
        private readonly AppDbContext _context;

        public PozisyonController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Pozisyonlar.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pozisyon pozisyon)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pozisyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozisyon);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var pozisyon = await _context.Pozisyonlar.FindAsync(id);
            if (pozisyon == null) return NotFound();
            return View(pozisyon);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pozisyon pozisyon)
        {
            if (id != pozisyon.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(pozisyon);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pozisyon);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var pozisyon = await _context.Pozisyonlar.FirstOrDefaultAsync(m => m.Id == id);
            if (pozisyon == null) return NotFound();
            return View(pozisyon);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pozisyon = await _context.Pozisyonlar.FindAsync(id);
            _context.Pozisyonlar.Remove(pozisyon);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
