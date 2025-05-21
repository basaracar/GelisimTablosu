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
        public async Task<IActionResult> Index()
        {
            var konular = await _context.Konular.Include(k => k.Kategori).ToListAsync();
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
    }
}
