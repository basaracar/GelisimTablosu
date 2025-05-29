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

    [HttpPost]
    async public Task<IActionResult> CreateTablo(GelisimTablosu.Models.ViewModels.TableModel model)
    {
        var random = new Random();
         DateTime startDate = new DateTime(2025, 9, 8);
        DateTime endDate = new DateTime(2026, 7, 26);
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
