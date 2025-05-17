using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dbdeneme.Data;
using dbdeneme.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dbdeneme.Controllers
{
    public class EgitimController : Controller
    {
        private readonly AppDbContext _context;

        public EgitimController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var egitimler = await _context.Egitimler.ToListAsync();
            return View(egitimler);
        }

        public async Task<IActionResult> Detay(int id)
        {
            var egitim = await _context.Egitimler
                .Include(e => e.PersonelEgitimler!)
                    .ThenInclude(pe => pe.Personel)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (egitim == null) return NotFound();

            ViewBag.PersonelListesi = new SelectList(_context.Personeller, "Id", "AdSoyad");
            return View(egitim);
        }

        [HttpPost]
        public async Task<IActionResult> PersonelEkle(int egitimId, int personelId, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            var zatenVarMi = await _context.PersonelEgitimler
                .AnyAsync(pe => pe.EgitimId == egitimId && pe.PersonelId == personelId);

            if (!zatenVarMi)
            {
                var yeni = new PersonelEgitim
                {
                    EgitimId = egitimId,
                    PersonelId = personelId,
                    BaslangicTarihi = baslangicTarihi,
                    BitisTarihi = bitisTarihi
                };
                _context.PersonelEgitimler.Add(yeni);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Detay", new { id = egitimId });
        }
    }
}
