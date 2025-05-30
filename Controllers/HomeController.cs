using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GelisimTablosu.Models;
using Microsoft.EntityFrameworkCore;
using GelisimTablosu.Utils;

namespace GelisimTablosu.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
      private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger, AppDbContext context){
        _context = context; 
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    [Route("/Home/Takvim/{id?}")]
    public IActionResult Takvim(int id)
    {
       var egitimYili = _context.EgitimYillari.FirstOrDefault(x => x.Id == id);
       ViewBag.EgitimYili = egitimYili.Id;
       
        var startDate = egitimYili.BaslangicTarihi;
        var endDate = egitimYili.BitisTarihi;
        var takvim = Helper.GetWeekdaysByMonthWeeks(startDate, endDate);
     //   ViewBag.Takvim = takvim;
        return View(takvim);
    }
    [HttpPost]
    public IActionResult TakvimEkle(int EgitimYili, List<string> hafta)
    {
        if (hafta != null && hafta.Count > 0)
        {
            foreach (var h in hafta)
            {
                var takvim = new Takvim
                {
                    Hafta = h,
                    EgitimYiliId = EgitimYili
                };
                _context.Takvimler.Add(takvim);
            }
            _context.SaveChanges();
            TempData["Success"] = "Takvim başarıyla kaydedildi.";
        }
        else
        {
            TempData["Error"] = "Hiçbir hafta seçilmedi.";
        }
        return RedirectToAction("Index");
    }

    [Route("/Home/TakvimGor/{id?}")]
    public IActionResult TakvimGor(int id)
    {
        var takvim = _context.Takvimler.Where(x => x.EgitimYiliId == id).ToList();
        if (takvim.Count == 0)
        {
            TempData["Error"] = "Bu eğitim yılı için takvim bulunamadı.";
            return RedirectToAction("Index");
        }
        return View(takvim);
    }

    [HttpPost]
    async public Task<IActionResult> CreateTablo(GelisimTablosu.Models.ViewModels.TableModel model)
    {
        var random = new Random();
         DateTime startDate = new DateTime(2025, 9, 8);
        DateTime endDate = new DateTime(2026, 6, 26);
        // API'den tatil günlerini al
        var holidays2025 = await Helper.GetHolidaysAsync(2025, "TR");
        var holidays2026 = await Helper.GetHolidaysAsync(2026, "TR");
        var holidays = holidays2025.Concat(holidays2026).ToList();


        // Hafta bazlı çalışma günlerini al
        var weeks = Helper.GetWeekdaysByWeekWithHolidays(startDate, endDate, holidays);
     //   var weeks = Helper.GetWeekdaysByWeek(startDate, endDate);
        if (ModelState.IsValid)
        {
            Dictionary<int, List<Konu>> konular = new Dictionary<int, List<Konu>>();
            List<Konu> tumKonular = new List<Konu>();
            Dictionary<int, List<Konu>> tamListe = new Dictionary<int, List<Konu>>();
            List<Kategori> kategoriler = await _context.Kategoriler.Where(x => x.Dal == model.Dal).ToListAsync();
            if (kategoriler.Count == 0)
            {
                ModelState.AddModelError("", "Bu dalda kategori bulunamadı.");
                return View(model);
            }
            foreach (var kategori in kategoriler)
            {
                var konus = (await _context.Konular
                    .Where(x => x.KategoriId == kategori.Id)
                    .ToListAsync())
                    .OrderBy(x => Guid.NewGuid())
                    .Take(model.Adet)
                    .ToList();
                konular.Add(kategori.Id, konus);
            }

            for (int i = 0; i < model.Adet; i++)
            {
                foreach (var kategori in kategoriler)
                {
                    var bune = konular[kategori.Id][i];
                    tumKonular.Add(bune);

                }
                tamListe.Add(i, tumKonular);
                tumKonular = new List<Konu>();
            }
            //ViewBag.tamListe = tamListe;
            return View(tamListe);
        }
        
        return View(model);
    }

    [HttpPost]
    public IActionResult TakvimSil(int id)
    {
        var takvim = _context.Takvimler.FirstOrDefault(x => x.Id == id);
        if (takvim != null)
        {
            _context.Takvimler.Remove(takvim);
            _context.SaveChanges();
            TempData["Success"] = "Hafta başarıyla silindi.";
        }
        else
        {
            TempData["Error"] = "Hafta bulunamadı.";
        }
        // Silinen kaydın eğitim yılına geri dön
        return RedirectToAction("TakvimGoster", new { id = takvim?.EgitimYiliId ?? 0 });
    }

    [HttpPost]
    public IActionResult TakvimTopluSil(int egitimYiliId)
    {
        var takvimler = _context.Takvimler.Where(x => x.EgitimYiliId == egitimYiliId).ToList();
        if (takvimler.Count > 0)
        {
            _context.Takvimler.RemoveRange(takvimler);
            _context.SaveChanges();
            TempData["Success"] = "Tüm takvim başarıyla silindi.";
        }
        else
        {
            TempData["Error"] = "Silinecek takvim bulunamadı.";
        }
        return RedirectToAction("TakvimGor", new { id = egitimYiliId });
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
