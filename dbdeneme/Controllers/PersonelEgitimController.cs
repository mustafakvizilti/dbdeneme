using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using dbdeneme.Data;
using dbdeneme.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace dbdeneme.Controllers
{
    public class PersonelEgitimController : Controller
    {
        private readonly AppDbContext _context;

        private static readonly List<(int Id, string Ad)> Egitimler = new List<(int, string)>
        {
            (1, "Bilgisayar Programcılığı"),
            (2, "İşletme Yönetimi"),
            (3, "Pazarlama"),
            (4, "Muhasebe"),
            (5, "İnsan Kaynakları")
        };

        public PersonelEgitimController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var liste = await _context.PersonelEgitimler
                .Include(pe => pe.Personel)
                .ToListAsync();

            var model = liste.Select(pe => new PersonelEgitimViewModel
            {
                Id = pe.Id,
                Personel = pe.Personel,
                EgitimId = pe.EgitimId,
                EgitimAd = Egitimler.FirstOrDefault(e => e.Id == pe.EgitimId).Ad
            }).ToList();

            return View(model);
        }

        public IActionResult Create()
        {
            ViewData["PersonelId"] = new SelectList(_context.Personeller, "Id", "Ad");
            ViewData["EgitimId"] = new SelectList(Egitimler.Select(e => new { Id = e.Id, Ad = e.Ad }), "Id", "Ad");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PersonelEgitim model)
        {
            if (!Egitimler.Any(e => e.Id == model.EgitimId))
            {
                ModelState.AddModelError("EgitimId", "Geçersiz eğitim seçimi.");
            }

            if (ModelState.IsValid)
            {
                _context.PersonelEgitimler.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["PersonelId"] = new SelectList(_context.Personeller, "Id", "Ad", model.PersonelId);
            ViewData["EgitimId"] = new SelectList(Egitimler.Select(e => new { Id = e.Id, Ad = e.Ad }), "Id", "Ad", model.EgitimId);
            return View(model);
        }

    }
}
