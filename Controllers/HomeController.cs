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

    public HomeController(ILogger<HomeController> logger, AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult Index(int? id)
    {
        if (id != null)
            ViewBag.egitimYili = id;
        ViewBag.EgitimYillari = _context.EgitimYillari.ToList();
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
        if (!ModelState.IsValid)
        {
            return View(model);
        }
      
        if (!await _context.OgrenciKonuAtamalari.Include("Student").AnyAsync(x => x.EgitimYiliId == model.EgitimYili && x.Student.Dal == model.Dal))
        {

              var resultList = new List<object>();
            var students = await _context.Students.Where(x => x.Dal == model.Dal).ToListAsync();
            var kategoriler = await _context.Kategoriler.Where(x => x.Dal == model.Dal).ToListAsync();
            if (kategoriler.Count == 0)
            {
                ModelState.AddModelError("Adet", "Bu dalda kategori bulunamadı.");
                return View(model);
            }

            var konular = new Dictionary<int, List<Konu>>();
            foreach (var kategori in kategoriler)
            {
                var konus = (await _context.Konular
                    .Where(x => x.KategoriId == kategori.Id).ToListAsync())
                    .OrderBy(x => Guid.NewGuid())
                    .Take(students.Count() * model.KonuAdet).ToList();
                if (konus.Count < students.Count() * model.KonuAdet)
                {
                    ModelState.AddModelError("adet", $"Kategori {kategori.Id} için yeterli konu bulunamadı.");
                    return View(model);
                }
                konular[kategori.Id] = konus;
            }

            // Her öğrenci için konuların atandığı liste
            
            var ogrenciKonular = new List<OgrenciKonuAtama>();
            for (int i = 0; i < students.Count(); i++)
            {
                var ogrenci = students[i];
                var ogrenciKategoriKonular = new List<object>();
                foreach (var kategori in kategoriler)
                {
                    var kategoriKonular = konular[kategori.Id]
                        .Skip(i * model.KonuAdet)
                        .Take(model.KonuAdet)
                        .ToList();

                    if (kategoriKonular.Count < model.KonuAdet)
                    {
                        ModelState.AddModelError("adet", $"Kategori {kategori.Id} için yeterli konu bulunamadı.");
                        continue;
                    }
                    ogrenciKategoriKonular.Add(kategoriKonular.Select(k => new
                        {
                            k.Id,
                            Baslik = k.Baslik,
                            Aciklama =k.Aciklama,
                            k.KategoriId
                        }));
                    foreach (var item in kategoriKonular)
                    {
                        
                        ogrenciKonular.Add(new OgrenciKonuAtama
                        {
                            StudentId = ogrenci.Id,
                            EgitimYiliId = model.EgitimYili,
                            KonuId = item.Id
                        });
                    }



                }
                resultList.Add(new
                {
                    Student = new
                    {
                        ogrenci.Id,
                        ogrenci.Ad,
                        ogrenci.Sinif,
                        Dal = ogrenci.Dal.ToString(),
                        Isletme = ogrenci.Isletme ?? "N/A"
                    },
                    Konular = ogrenciKategoriKonular
                });


            }
            await _context.OgrenciKonuAtamalari.AddRangeAsync(ogrenciKonular);
            await _context.SaveChangesAsync();
            ViewBag.tamListe = resultList;
            return View("CreateTablo");
        }

        else
        {
            // Kayıtlı OgrenciKonuAtama verilerini getir
            var kayitliAtamalar = await _context.OgrenciKonuAtamalari
                .Include(x => x.Student)
                .Include(x => x.EgitimYili)
                .Include(x => x.Konu)
                .Where(x => x.EgitimYiliId == model.EgitimYili && x.Student != null && x.Student.Dal == model.Dal)
                .ToListAsync();

            // resultList formatında ViewBag.tamListe oluştur
            var resultList = kayitliAtamalar
                .GroupBy(x => x.StudentId)
                .Select(g => new
                {
                    Student = g.First().Student != null ? new
                    {
                        Id = g.First().Student.Id,
                        Ad = g.First().Student.Ad,
                        Sinif = g.First().Student.Sinif,
                        Dal = g.First().Student.Dal != null ? g.First().Student.Dal.ToString() : "",
                        Isletme = g.First().Student.Isletme ?? "N/A"
                    } : null,
                    Konular = g.Select(a => a.Konu != null ? new
                    {
                        Id = a.Konu.Id,
                        Baslik = a.Konu.Baslik,
                        Aciklama = a.Konu.Aciklama,
                        KategoriId = a.Konu.KategoriId
                    } : null).Where(k => k != null).ToList()
                })
                .ToList();

            ViewBag.tamListe = resultList;
            return View("CreateTablo");
        }
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
