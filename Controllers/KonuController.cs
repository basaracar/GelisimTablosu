using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GelisimTablosu.Models;

namespace GelisimTablosu.Controllers
{
    public class KonuController : Controller
    {
        private readonly AppDbContext _context;
        public KonuController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Konu
        [Route("Konu/Index/{kategoriId?}")]
        public async Task<IActionResult> Index(int kategoriId = 1)
        {
            var konular = await _context.Konular.Include(k => k.Kategori).Where(x => x.KategoriId == kategoriId).ToListAsync();
            ViewBag.Kategoriler = await _context.Kategoriler.ToListAsync();
            ViewBag.KategoriId = kategoriId;
            return View(konular);
        }

        // GET: Konu/Create
        public IActionResult Create()
        {
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View();
        }

        // POST: Konu/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Baslik,Zorluk,KategoriId")] Konu konu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(konu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View(konu);
        }

        // GET: Konu/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var konu = await _context.Konular.FindAsync(id);
            if (konu == null)
            {
                return NotFound();
            }
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View(konu);
        }

        // POST: Konu/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Baslik,Aciklama,Dal,Zorluk,KategoriId")] Konu konu)
        {
            if (id != konu.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(konu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Konular.Any(e => e.Id == konu.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View(konu);
        }

    }
}
