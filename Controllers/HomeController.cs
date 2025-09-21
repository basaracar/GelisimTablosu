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
        // ModelState geçerli mi kontrol edilir
        if (!ModelState.IsValid)
        {
            // Model geçerli değilse aynı view tekrar döndürülür
            return View(model);
        }
        // Seçilen dal ViewBag'e atanır
        ViewBag.Dal = model.Dal;
        // Eğer bu eğitim yılı ve dal için daha önce atama yapılmamışsa
        if (!await _context.OgrenciKonuAtamalari.Include("Student").AnyAsync(x => x.EgitimYiliId == model.EgitimYili && x.Student.Dal == model.Dal))
        {
            // Sonuçları tutacak liste oluşturulur
            var resultList = new List<object>();
            // Seçilen dala ait öğrenciler çekilir
            var students = await _context.Students.Where(x => x.Dal == model.Dal).ToListAsync();
            // Seçilen dala ait kategoriler çekilir
            var kategoriler = await _context.Kategoriler.Where(x => x.Dal == model.Dal).ToListAsync();
            // Eğer kategori yoksa hata döndürülür
            if (kategoriler.Count == 0)
            {
                ModelState.AddModelError("Adet", "Bu dalda kategori bulunamadı.");
                return View(model);
            }

            // Her kategori için konular sözlüğü oluşturulur
            var konular = new Dictionary<int, List<Konu>>();
            foreach (var kategori in kategoriler)
            {
                // Her kategori için rastgele konular seçilir
                var konus = (await _context.Konular
                    .Where(x => x.KategoriId == kategori.Id).ToListAsync())
                    .OrderBy(x => Guid.NewGuid())
                    .Take(students.Count() * model.KonuAdet).ToList();
                // Yeterli konu yoksa hata döndürülür
                if (konus.Count < students.Count() * model.KonuAdet)
                {
                    ModelState.AddModelError("adet", $"Kategori {kategori.Id} için yeterli konu bulunamadı.");
                    return View(model);
                }
                // Seçilen konular sözlüğe eklenir
                konular[kategori.Id] = konus;
            }

            // Her öğrenci için konuların atandığı liste oluşturulur
            var ogrenciKonular = new List<OgrenciKonuAtama>();
            for (int i = 0; i < students.Count(); i++)
            {
                // İlgili öğrenci alınır
                var ogrenci = students[i];
                // Öğrencinin kategorilere göre konuları tutulacak liste
                var ogrenciKategoriKonular = new List<object>();
                foreach (var kategori in kategoriler)
                {
                    // O öğrenciye atanacak konular seçilir
                    var kategoriKonular = konular[kategori.Id]
                        .Skip(i * model.KonuAdet)
                        .Take(model.KonuAdet)
                        .ToList();

                    // Yeterli konu yoksa hata eklenir ve devam edilir
                    if (kategoriKonular.Count < model.KonuAdet)
                    {
                        ModelState.AddModelError("adet", $"Kategori {kategori.Id} için yeterli konu bulunamadı.");
                        continue;
                    }
                    // Öğrenciye atanacak konular listeye eklenir
                    ogrenciKategoriKonular.Add(kategoriKonular.Select(k => new
                    {
                        k.Id,
                        Baslik = k.Baslik,
                        Aciklama = k.Aciklama,
                        KategoriId = k.Kategori?.Ad
                    }));
                    // Her konu için OgrenciKonuAtama nesnesi oluşturulur
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
                // Sonuç listesine öğrenci ve konuları eklenir
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
            // OgrenciKonuAtama nesneleri veritabanına eklenir
            await _context.OgrenciKonuAtamalari.AddRangeAsync(ogrenciKonular);
            // Değişiklikler kaydedilir
            await _context.SaveChangesAsync();
            // Sonuçlar ViewBag'e atanır
            ViewBag.tamListe = resultList;

            // CreateTablo view'i döndürülür
            return View("CreateTablo");
        }
        // Eğer daha önce atama yapılmışsa
        else
        {
            // Kayıtlı OgrenciKonuAtama verilerini getir
            var kayitliAtamalar = await _context.OgrenciKonuAtamalari
                .Include(x => x.Student)
                .Include(x => x.EgitimYili)
                .Include(x => x.Konu)
                .Include(x => x.Konu.Kategori)
                .Where(x => x.EgitimYiliId == model.EgitimYili && x.Student != null && x.Student.Dal == model.Dal)
                .ToListAsync();

            // resultList formatında ViewBag.tamListe oluştur
            var resultList = kayitliAtamalar
                .GroupBy(x => x.StudentId)
                .Select(g =>
                {
                    var firstStudent = g.FirstOrDefault(x => x.Student != null)?.Student;
                    return new
                    {
                        Student = firstStudent != null ? new
                        {
                            Id = firstStudent.Id,
                            Ad = firstStudent.Ad,
                            Sinif = firstStudent.Sinif,
                            Dal = firstStudent.Dal.ToString(),
                            Isletme = firstStudent.Isletme ?? "N/A"
                        } : null,
                        Konular = g.Select(a => a.Konu != null ? new
                        {
                            Id = a.Konu.Id,
                            Baslik = a.Konu.Baslik,
                            Aciklama = a.Konu.Aciklama,
                            KategoriId = a.Konu.Kategori?.Ad
                        } : null).Where(k => k != null).ToList()
                    };
                })
                .ToList();

            // Sonuçlar ViewBag'e atanır
            ViewBag.tamListe = resultList;
            // CreateTablo view'i döndürülür
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
