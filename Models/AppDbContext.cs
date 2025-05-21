using Microsoft.EntityFrameworkCore;
using GelisimTablosu.Models;

namespace GelisimTablosu.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Konu> Konular { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konu ile Kategori arasında bire çok ilişki
            modelBuilder.Entity<Konu>()
                .HasOne(k => k.Kategori)
                .WithMany()
                .HasForeignKey(k => k.KategoriId)
                .OnDelete(DeleteBehavior.Cascade);


            base.OnModelCreating(modelBuilder);
        }
        public async Task SeedKategori()
        {
            if (!Kategoriler.Any())
            {
                Kategoriler.Add(new Kategori { Id = 1, Ad = "Python Projeleri" });

                await SaveChangesAsync();
            }
        }
        public async Task SeedKonu()
        {
            if (!Konular.Any())
            {
                Konular.Add(new Konu { Id = 1, Baslik = "Hesap Makinesi Uygulaması", Aciklama = "Toplama, çıkarma, çarpma, bölme işlemleri yapan basit bir hesap makinesi.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 2, Baslik = "Not Ortalaması Hesaplayıcı", Aciklama = "Girilen ders notlarına göre ortalama hesaplayıp geçip kalma durumu gösteren uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 3, Baslik = "ATM Simülasyonu", Aciklama = "Para çekme, para yatırma, bakiye görüntüleme işlemleri yapılabilir.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 4, Baslik = "Sayı Tahmin Oyunu", Aciklama = "Bilgisayarın rastgele tuttuğu sayıyı tahmin etmeye çalışılan oyun.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 5, Baslik = "Şifre Güçlülüğü Kontrolü", Aciklama = "Girilen şifrenin uzunluğu ve karakter çeşitliliğine göre zorluk derecesini hesaplar.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 8, Baslik = "Sözlük Uygulaması", Aciklama = "İngilizce kelimenin Türkçesini gösteren mini sözlük (hazır bir dictionary yapısı ile).", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 7, Baslik = "Basit Rehber Uygulaması", Aciklama = "Kişi ekleme, silme, arama işlemleri yapılabilen telefon rehberi.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 9, Baslik = "Yarışma (Quiz) Uygulaması", Aciklama = "5-10 soruluk bir bilgi yarışması. Kullanıcıdan cevap alıp puan hesaplar.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 10, Baslik = "Doğum Günü Hatırlatıcı", Aciklama = "Kayıtlı kişilerin doğum günlerini saklar ve sorgulama yapılabilir.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 12, Baslik = "Çarpım Tablosu Yazdırıcı", Aciklama = "Kullanıcının girdiği sayıya kadar çarpım tablosu oluşturan program.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
               Konular.Add( new Konu { Id = 11, Baslik = "Zar Atma Simülatörü", Aciklama = "1 ile 6 arasında rastgele zar atan uygulama. İstenirse çift zarla yapılabilir.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 13, Baslik = "Metin Şifreleme (Caesar Cipher)", Aciklama = "Girilen metni belirli bir kaydırmayla şifreleyen ve çözebilen uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
                Konular.Add(new Konu { Id = 14, Baslik = "Kelime Sayacı", Aciklama = "Kullanıcının girdiği metindeki kelime ve harf sayısını bulur.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
               Konular.Add( new Konu { Id = 15, Baslik = "Dosya Kayıt ve Okuma Uygulaması", Aciklama = "Kullanıcı bilgilerini .txt dosyasına kaydeder ve okur.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
               Konular.Add( new Konu { Id = 16, Baslik = "Dijital Saat Gösterimi (Saniyelik)", Aciklama = "Anlık olarak saat/dakika/saniye gösteren mini saat simülasyonu. (Zaman modülü kullanılarak)", Zorluk = Zorluk.Kolay, KategoriId = 1 });
               Konular.Add( new Konu { Id = 17, Baslik = "Basit Takvim Görüntüleyici", Aciklama = "Ay ve yıl girildiğinde o ayın takvimini gösterir (calendar modülü ile).", Zorluk = Zorluk.Kolay, KategoriId = 1 });
               Konular.Add( new Konu { Id = 18, Baslik = "Asal Sayı Bulucu", Aciklama = "Girilen aralıkta asal sayıları listeler.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
               Konular.Add( new Konu { Id = 19, Baslik = "Faktöriyel Hesaplayıcı", Aciklama = "Kullanıcının girdiği sayının faktöriyelini hesaplar.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
               Konular.Add( new Konu { Id = 20, Baslik = "Mini Alışveriş Sepeti", Aciklama = "Kullanıcı ürün ekler, siler ve toplam fiyatı gösteren basit bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
           


            }
            await SaveChangesAsync();
        }
    }
}
