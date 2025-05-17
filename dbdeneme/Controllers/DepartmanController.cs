using Microsoft.AspNetCore.Mvc;
using dbdeneme.Models;
using dbdeneme.Data;

using Microsoft.EntityFrameworkCore;

namespace dbdeneme.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmanController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Departmanlar.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Departman departman)
        {
            if (ModelState.IsValid)
            {
                _context.Add(departman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departman);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var departman = await _context.Departmanlar.FindAsync(id);
            if (departman == null) return NotFound();
            return View(departman);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Departman departman)
        {
            if (id != departman.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(departman);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(departman);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var departman = await _context.Departmanlar.FirstOrDefaultAsync(m => m.Id == id);
            if (departman == null) return NotFound();
            return View(departman);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var departman = await _context.Departmanlar.FindAsync(id);
            _context.Departmanlar.Remove(departman);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
