using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dbdeneme.Data;
using dbdeneme.Models;

namespace dbdeneme.Controllers
{
    public class PersonelController : Controller
    {
        private readonly AppDbContext _context;

        public PersonelController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var personeller = await _context.Personeller
                .Include(p => p.Departman)
                .Include(p => p.Pozisyon)
                .Include(p => p.Maaslar)
                .ToListAsync();

            return View(personeller);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Personel personel, Maas maas)
        {
            if (ModelState.IsValid)
            {
                _context.Personeller.Add(personel);
                await _context.SaveChangesAsync();

                maas.PersonelId = personel.Id;
                _context.Maaslar.Add(maas);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            foreach (var error in errors)
            {
                Console.WriteLine(error);
            }

            return View(personel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Personeller == null)
                return NotFound();

            var personel = await _context.Personeller
                .Include(p => p.Departman)
                .Include(p => p.Pozisyon)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (personel == null)
                return NotFound();

            return View(personel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personel = await _context.Personeller.FindAsync(id);
            if (personel != null)
            {
                _context.Personeller.Remove(personel);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> MaasEdit(int? personelId)
        {
            if (personelId == null)
                return NotFound();

            var maas = await _context.Maaslar
                .Where(m => m.PersonelId == personelId)
                .OrderByDescending(m => m.OdemeTarihi)
                .FirstOrDefaultAsync();

            if (maas == null)
                return NotFound();

            return View(maas);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MaasEdit(int id, Maas maas)
        {
            if (id != maas.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(maas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Maaslar.Any(e => e.Id == maas.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(maas);
        }
    }
}
