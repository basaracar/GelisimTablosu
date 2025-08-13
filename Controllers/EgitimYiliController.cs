using Microsoft.AspNetCore.Mvc;
using GelisimTablosu.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GelisimTablosu.Controllers
{
    public class EgitimYiliController : Controller
    {
        private readonly AppDbContext _context;
        public EgitimYiliController(AppDbContext context)
        {
            _context = context;
        }

        // GET: EgitimYili
        public async Task<IActionResult> Index()
        {
            var takvimler = new Dictionary<int, List<bool>>();
            var list = await _context.EgitimYillari.ToListAsync();
            foreach (var item in list)
            {
                var bayraklar = new List<bool>();
                bayraklar.Add(await _context.Takvimler.AnyAsync(x => x.EgitimYiliId == item.Id));
                if (await _context.OgrenciKonuAtamalari.AnyAsync(x => x.EgitimYiliId == item.Id))
                {
                    var yazilimOgrencisi = await _context.OgrenciKonuAtamalari
                        .Include(x => x.Student)
                        .AnyAsync(x => x.EgitimYiliId == item.Id && x.Student.Dal == Dal.Yazilim);
                    bayraklar.Add(yazilimOgrencisi);
                    var agOgrencisi = await _context.OgrenciKonuAtamalari
                        .Include(x => x.Student)
                        .AnyAsync(x => x.EgitimYiliId == item.Id && x.Student.Dal == Dal.Ag);
                    bayraklar.Add(agOgrencisi);
                }
                else
                {
                    // Eğer hiç öğrenci ataması yoksa, false ekle
                    bayraklar.Add(false); // Yazılım
                    bayraklar.Add(false); // Ağ
                }
                takvimler.Add(item.Id, bayraklar);
            }

            ViewBag.Takvimler = takvimler;  
            return View(list);
        }

        // GET: EgitimYili/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EgitimYili/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EgitimYili model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: EgitimYili/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var egitimYili = await _context.EgitimYillari.FindAsync(id);
            if (egitimYili == null) return NotFound();
            return View(egitimYili);
        }

        // POST: EgitimYili/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EgitimYili model)
        {
            if (id != model.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: EgitimYili/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var egitimYili = await _context.EgitimYillari.FindAsync(id);
            if (egitimYili == null) return NotFound();
            return View(egitimYili);
        }

        // POST: EgitimYili/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var egitimYili = await _context.EgitimYillari.FindAsync(id);
            if (egitimYili != null)
            {
                _context.EgitimYillari.Remove(egitimYili);
                _context.Takvimler.RemoveRange(_context.Takvimler.Where(x => x.EgitimYiliId == id).ToList());
                _context.OgrenciKonuAtamalari.RemoveRange(_context.OgrenciKonuAtamalari.Where(x => x.EgitimYiliId == id).ToList());
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
