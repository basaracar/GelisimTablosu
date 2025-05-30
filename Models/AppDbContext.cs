using Microsoft.EntityFrameworkCore;
using GelisimTablosu.Models;

namespace GelisimTablosu.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Konu> Konular { get; set; }
        public DbSet<EgitimYili> EgitimYillari { get; set; }
        public DbSet<Takvim> Takvimler { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konu ile Kategori arasında bire çok ilişki
            modelBuilder.Entity<Konu>()
                .HasOne(k => k.Kategori)
                .WithMany()
                .HasForeignKey(k => k.KategoriId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Takvim>()
            .HasOne(G => G.EgitimYili)
            .WithMany()
            .HasForeignKey(g => g.EgitimYiliId);
            base.OnModelCreating(modelBuilder);
        }
        public async Task SeedKategori()
        {
            if (!Kategoriler.Any())
            {
                Kategoriler.Add(new Kategori {  Ad = "Python Projeleri",Dal = Dal.Yazilim });
                Kategoriler.Add(new Kategori {  Ad = "Robotik Kodlama" ,Dal = Dal.Yazilim });
                Kategoriler.Add(new Kategori {  Ad = "C# Projeleri" ,Dal = Dal.Yazilim });
                Kategoriler.Add(new Kategori { Ad = "Web Tasarım HTML" ,Dal = Dal.Yazilim });
                Kategoriler.Add(new Kategori {  Ad = "Mobil Uygulamalar" ,Dal = Dal.Yazilim });
              //  Kategoriler.Add(new Kategori {  Ad = "Oyun Geliştirme" });
                Kategoriler.Add(new Kategori {  Ad = "Grafik Tasarım",Dal = Dal.Yazilim  });
                Kategoriler.Add(new Kategori {  Ad = "Web Tasarım ASP" ,Dal = Dal.Yazilim });
                Kategoriler.Add(new Kategori {  Ad = "Web Tasarım PHP" ,Dal = Dal.Yazilim });
                Kategoriler.Add(new Kategori {  Ad = "Ağ Sistemleri Anahtarlama" ,Dal = Dal.Ag});
                Kategoriler.Add(new Kategori {  Ad = "Ağ Sistemleri ve Yönlendirme" ,Dal = Dal.Ag});
                
                Kategoriler.Add(new Kategori {  Ad = "Siber Güvenlik Temelleri" ,Dal = Dal.Ag});
                Kategoriler.Add(new Kategori {  Ad = "Sunucu İşletim Sistemi" ,Dal = Dal.Ag});

                await SaveChangesAsync();
            }
        }
        public async Task SeedKonu()
        {
            if (!Konular.Any())
            {
                var konular = new List<Konu>();
   konular.Add(new Konu { Baslik = "Hesap Makinesi Uygulaması", Aciklama = "Toplama, çıkarma, çarpma, bölme işlemleri yapan basit bir hesap makinesi.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Not Ortalaması Hesaplayıcı", Aciklama = "Girilen ders notlarına göre ortalama hesaplayıp geçip kalma durumu gösteren uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "ATM Simülasyonu", Aciklama = "Para çekme, para yatırma, bakiye görüntüleme işlemleri yapılabilir.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Sayı Tahmin Oyunu", Aciklama = "Bilgisayarın rastgele tuttuğu sayıyı tahmin etmeye çalışılan oyun.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Şifre Güçlülüğü Kontrolü", Aciklama = "Girilen şifrenin uzunluğu ve karakter çeşitliliğine göre zorluk derecesini hesaplar.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Sözlük Uygulaması", Aciklama = "İngilizce kelimenin Türkçesini gösteren mini sözlük (hazır bir dictionary yapısı ile).", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Basit Rehber Uygulaması", Aciklama = "Kişi ekleme, silme, arama işlemleri yapılabilen telefon rehberi.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Yarışma (Quiz) Uygulaması", Aciklama = "5-10 soruluk bir bilgi yarışması. Kullanıcıdan cevap alıp puan hesaplar.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Doğum Günü Hatırlatıcı", Aciklama = "Kayıtlı kişilerin doğum günlerini saklar ve sorgulama yapılabilir.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Çarpım Tablosu Yazdırıcı", Aciklama = "Kullanıcının girdiği sayıya kadar çarpım tablosu oluşturan program.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Zar Atma Simülatörü", Aciklama = "1 ile 6 arasında rastgele zar atan uygulama. İstenirse çift zarla yapılabilir.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Metin Şifreleme (Caesar Cipher)", Aciklama = "Girilen metni belirli bir kaydırmayla şifreleyen ve çözebilen uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Kelime Sayacı", Aciklama = "Kullanıcının girdiği metindeki kelime ve harf sayısını bulur.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Dosya Kayıt ve Okuma Uygulaması", Aciklama = "Kullanıcı bilgilerini .txt dosyasına kaydeder ve okur.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Dijital Saat Gösterimi (Saniyelik)", Aciklama = "Anlık olarak saat/dakika/saniye gösteren mini saat simülasyonu. (Zaman modülü kullanılarak)", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Basit Takvim Görüntüleyici", Aciklama = "Ay ve yıl girildiğinde o ayın takvimini gösterir (calendar modülü ile).", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Asal Sayı Bulucu", Aciklama = "Girilen aralıkta asal sayıları listeler.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Faktöriyel Hesaplayıcı", Aciklama = "Kullanıcının girdiği sayının faktöriyelini hesaplar.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Mini Alışveriş Sepeti", Aciklama = "Kullanıcı ürün ekler, siler ve toplam fiyatı gösteren basit bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "Basit Not Defteri Uygulaması", Aciklama = "Kullanıcı not ekleyebilir, silebilir ve kaydedebilir.", Zorluk = Zorluk.Kolay, KategoriId = 1 });
konular.Add(new Konu { Baslik = "LED Yak Söndür (Butonla Kontrol)", Aciklama = "Bir butona basınca LED’in yanıp sönmesi.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Yanıp Sönen LED (Blink)", Aciklama = "Belirli aralıklarla yanıp sönen LED (Arduino’nun klasik ilk projesi).", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Trafik Lambası Simülasyonu", Aciklama = "Kırmızı, sarı ve yeşil LED’lerle trafik ışığı döngüsü oluşturma.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "RGB LED Renk Değişimi", Aciklama = "RGB LED ile renk geçişleri veya butonla renk değiştirme.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Potansiyometre ile LED Parlaklık Kontrolü", Aciklama = "Potansiyometreyi çevirerek LED’in parlaklığını ayarlama.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "LDR ile Ortam Işığına Göre LED Kontrolü", Aciklama = "Ortam karardıkça LED’in yanması (ışığa duyarlı sistem).", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Buzzer ile Uyarı Sistemi", Aciklama = "Buzzer’dan belirli tonlarda ses çıkarma (örneğin alarm sesi).", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Sıcaklık ve Nem Göstergesi (DHT11 ile)", Aciklama = "DHT11 sensörü ile sıcaklık ve nemin seri ekrana yazdırılması.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Mesafe Ölçer (Ultrasonik Sensör ile)", Aciklama = "HC-SR04 sensörü ile cisimle mesafe ölçme.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Engelden Kaçan Sistem (Mini Robot)", Aciklama = "Ultrasonik sensör ile engelden kaçan basit robot (servo kullanılabilir).", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Butonla Sayı Sayıcı", Aciklama = "Her butona basıldığında seri monitöre 1 artırarak sayıyı yazma.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Servo Motor ile Kapı Açma Kapatma", Aciklama = "Butonla veya potansiyometreyle servo motoru 0–180 derece döndürme.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Dijital Termometre (LCD ile Gösterim)", Aciklama = "DHT11 sıcaklık sensöründen alınan veriyi LCD ekranda gösterme.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Karanlıkta Otomatik Yanan Gece Lambası", Aciklama = "LDR kullanarak ortam karanlık olduğunda LED’i açma.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Mini Alarm Sistemi (LDR + Buzzer)", Aciklama = "Üzeri örtülmüş LDR açılınca alarm veren sistem.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Arduino ile Dice (Zar Atma Simülasyonu)", Aciklama = "Butona basınca rastgele 1–6 arası sayı ve LED kombinasyonu.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "IR Uzaktan Kumanda ile LED Kontrolü", Aciklama = "TV kumandası gibi bir IR kumanda ile LED’leri açıp kapatma.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Sesle Kontrol (Ses Sensörü ile)", Aciklama = "Alkış sesi gibi yüksek sesle LED veya buzzer çalıştırma.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Parola ile LED Açma (Serial Monitör Üzerinden)", Aciklama = "Belirli bir parola girilince LED’in açılması.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Zamanlayıcı LED (Gecikmeli Kapanma)", Aciklama = "Butona basınca LED yanar ve 10 saniye sonra otomatik söner.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Toprak Nem Sensörü ile Sulama Uyarı Sistemi", Aciklama = "Toprak kuruysa LED yanar ve buzzer öter.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "7 Segment Display ile Sayı Gösterimi", Aciklama = "0’dan 9’a kadar sayıları 7 segment üzerinde gösterme.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Joystick ile LED Parlaklık Kontrolü", Aciklama = "Joystick modülüyle bir LED’in parlaklığını veya servo pozisyonunu kontrol etme.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Basit Park Sensörü (Mesafeye Göre Buzzer)", Aciklama = "Araç park sistemi benzeri, yaklaştıkça buzzer sesi artar.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Klavye ile Arduino Kontrolü (Serial üzerinden)", Aciklama = "Klavyeden girilen komutlara göre LED aç/kapa işlemleri.", Zorluk = Zorluk.Kolay, KategoriId = 2 });
konular.Add(new Konu { Baslik = "Kişisel Blog Sitesi", Aciklama = "Yazı ekleme, düzenleme, silme, yorum yapma, kategorilere ayırma.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Haber Sitesi", Aciklama = "Admin panelinden haber ekleme, ana sayfada listeleme, detay sayfası.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Kütüphane Takip Sistemi", Aciklama = "Kitap, yazar, kategori yönetimi; ödünç verme ve iade etme işlemleri.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Online Not Sistemi (Öğrenci için)", Aciklama = "Öğrencilerin ders ve not bilgilerini görüntülediği sistem.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Basit E-Ticaret Sitesi (Sepetsiz)", Aciklama = "Ürün listeleme, ürün detayları, kategori filtreleme.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Ziyaretçi Defteri Uygulaması", Aciklama = "Ziyaretçilerin mesaj bırakabileceği bir sayfa ve admin kontrol paneli.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "İletişim Formu + Mesaj Kayıt Sistemi", Aciklama = "Kullanıcıların iletişim formu doldurup, verilerin admin panelinden görülmesi.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "CV Paylaşım Sitesi (Kariyer Profili)", Aciklama = "Kullanıcılar eğitim, deneyim, beceri gibi verileri girer ve CV görüntülenir.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Etkinlik Takip Uygulaması", Aciklama = "Etkinlik ekleme, listeleme, kullanıcıların etkinliğe katılma durumu.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Duyuru ve Haber Yönetim Paneli", Aciklama = "Adminlerin duyuru ekleyebileceği, kullanıcıların okuyabileceği bir platform.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Sınav Takip ve Sonuç Sistemi", Aciklama = "Öğrenciler sınavlara katılır, admin puan girer ve öğrenci sonucu görür.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Galeri Uygulaması (Resim Yükleme)", Aciklama = "Kullanıcılar veya admin tarafından resim yüklenip kategorilere ayrılır.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Kullanıcı Kayıt / Giriş Sistemi (Authentication)", Aciklama = "Kayıt, giriş, çıkış işlemleri; kullanıcı yetkilendirmesi.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "To-Do List (Görev Takip Uygulaması)", Aciklama = "Kullanıcılar görev ekleyebilir, tamamlandı olarak işaretleyebilir.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Yorum ve Oylama Sistemi", Aciklama = "Kullanıcılar içeriklere yıldızla puan verebilir ve yorum yazabilir.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Online Rezervasyon Sistemi (Randevu)", Aciklama = "Kullanıcılar tarih ve saat seçerek randevu alabilir (örnek: berber, dişçi vb).", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Hava Durumu Göstergesi (API ile)", Aciklama = "Lokasyon girerek o şehrin güncel hava durumunu gösteren uygulama (açık hava durumu API ile).", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Mini Forum Uygulaması", Aciklama = "Konu oluşturma, yorum yazma, kullanıcılar arası etkileşim.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Basit Blog Yönetim Sistemi (Admin Paneli ile)", Aciklama = "CRUD işlemleri: Blog ekle, sil, güncelle; kullanıcılar okuyabilir.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Film / Dizi İnceleme Platformu", Aciklama = "Filmler listelenir, kullanıcılar yorum yapabilir ve puan verebilir.", Zorluk = Zorluk.Kolay, KategoriId = 7 });
konular.Add(new Konu { Baslik = "Not Defteri Uygulaması", Aciklama = "Metin yazma, kaydetme ve düzenleme yapabilen basit bir metin editörü.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Hesap Makinesi", Aciklama = "Temel matematiksel işlemler (toplama, çıkarma, çarpma, bölme) yapan bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Görev Yönetim Uygulaması", Aciklama = "Kullanıcıların görev ekleyip, tamamlandı olarak işaretleyebileceği bir to-do listesi.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Döviz Çevirici", Aciklama = "Farklı para birimleri arasında sabit kurlarla dönüşüm yapan bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Kişisel Ajanda", Aciklama = "Tarih ve saat bazlı etkinlik ekleme, düzenleme ve hatırlatma özelliği.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Sözlük Uygulaması", Aciklama = "Kelimelerin anlamlarını kaydedip aratılabilen bir masaüstü sözlük.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Resim Görüntüleyici", Aciklama = "Kullanıcının seçtiği resimleri görüntüleyip yakınlaştırma/uzaklaştırma yapabilen uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Bütçe Takip Sistemi", Aciklama = "Gelir ve giderlerin kaydedilip basit raporlar sunan bir finans uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Hava Durumu Görüntüleyici", Aciklama = "Sabit veri veya basit bir API ile şehirlerin hava durumunu gösteren uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Basit Oyun (Yılan Oyunu)", Aciklama = "Klavyeyle kontrol edilen klasik yılan oyununun masaüstü versiyonu.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Telefon Rehberi", Aciklama = "Kişi ekleme, düzenleme ve arama özellikli bir rehber uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Dosya Düzenleyici", Aciklama = "Belirli bir klasördeki dosyaları uzantılarına göre kategorize eden uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Kronometre ve Zamanlayıcı", Aciklama = "Süre ölçen ve geri sayım yapabilen bir kronometre uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Basit Çizim Uygulaması", Aciklama = "Fare ile basit şekiller çizip renk seçimi yapılabilen bir çizim aracı.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Şifre Oluşturucu", Aciklama = "Rastgele güvenli şifreler üreten ve kaydeden bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Kütüphane Yönetim Sistemi", Aciklama = "Kitap ekleme, silme ve ödünç alma işlemlerini takip eden bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Sınav Sonuç Hesaplayıcı", Aciklama = "Öğrenci notlarını girip ortalama ve başarı durumunu hesaplayan uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Birim Çevirici", Aciklama = "Uzunluk, ağırlık, hacim gibi birimler arasında dönüşüm yapan uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Rastgele Sayı Üretici", Aciklama = "Belirtilen aralıkta rastgele sayılar üreten ve kaydeden bir araç.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Metin Analiz Aracı", Aciklama = "Girilen metindeki kelime ve karakter sayısını analiz eden uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 3 });
konular.Add(new Konu { Baslik = "Kişisel Portfolyo Sayfası", Aciklama = "Kişisel bilgiler, beceriler ve projeleri tanıtan tek sayfalık bir portfolyo sitesi.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Restoran Menü Sayfası", Aciklama = "Yemek kategorileri ve fiyatları içeren stilize bir restoran menüsü.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Etkinlik Tanıtım Sayfası", Aciklama = "Bir konser veya etkinlik için tarih, yer ve detayları gösteren bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Fotoğraf Galerisi", Aciklama = "Resimlerin düzenli bir ızgara düzeninde sergilendiği bir galeri sayfası.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Blog Ana Sayfası", Aciklama = "Statik blog yazıları ve kategorilerin listelendiği bir ana sayfa tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "İletişim Formu Sayfası", Aciklama = "Kullanıcıların ad, e-posta ve mesaj girebileceği bir iletişim formu.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Ürün Tanıtım Sayfası", Aciklama = "Tek bir ürünün resimleri, açıklaması ve özelliklerini gösteren sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Hakkımda Sayfası", Aciklama = "Kişisel bilgiler, fotoğraf ve sosyal medya bağlantılarının yer aldığı bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Seyahat Blogu Sayfası", Aciklama = "Seyahat destinasyonlarının fotoğraflı kartlarla tanıtıldığı bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Basit Özgeçmiş Sitesi", Aciklama = "Eğitim, deneyim ve becerilerin listelendiği bir CV sayfası.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Yemek Tarifi Sayfası", Aciklama = "Bir yemek tarifinin malzemeleri ve yapılış adımlarını gösteren sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Hava Durumu Kartı", Aciklama = "Statik veriyle bir şehrin hava durumunu gösteren stilize bir kart tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Egzersiz Takip Sayfası", Aciklama = "Egzersiz programlarının listelendiği ve görsel olarak düzenlenmiş bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Film Tanıtım Sayfası", Aciklama = "Bir filmin afişi, özeti ve oyuncu listesinin yer aldığı bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Düğün Davetiyesi Sayfası", Aciklama = "Düğün detayları ve RSVP formu içeren zarif bir davetiye tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Alışveriş Listesi Sayfası", Aciklama = "Kullanıcıların alışveriş listelerini görsel olarak düzenleyen bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Müzik Çalma Listesi", Aciklama = "Şarkıların listelendiği ve albüm kapaklarının gösterildiği bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Spor Salonu Tanıtımı", Aciklama = "Spor salonunun hizmetlerini ve programlarını tanıtan bir ana sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Kitap Tanıtım Sayfası", Aciklama = "Bir kitabın kapağı, özeti ve yazar bilgilerinin yer aldığı sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Minimalist Saat Tasarımı", Aciklama = "CSS ile stilize edilmiş bir dijital veya analog saat gösteren sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
konular.Add(new Konu { Baslik = "Basit Hesap Makinesi", Aciklama = "PHP ile form üzerinden girilen sayılarla temel matematiksel işlemler yapan bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Döviz Çevirici", Aciklama = "Sabit kurlarla para birimleri arasında dönüşüm yapan bir PHP formu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Giriş Formu Kontrolü", Aciklama = "Kullanıcı adı ve şifreyi kontrol eden basit bir PHP login sayfası.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Sayı Tahmin Oyunu", Aciklama = "PHP ile rastgele bir sayıyı tahmin etmeye çalışan bir web oyunu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Basit Anket Sistemi", Aciklama = "Kullanıcıların bir soruya oy verip sonuçları gören bir PHP anket sayfası.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Metin Analiz Aracı", Aciklama = "Girilen metnin kelime ve karakter sayısını hesaplayan bir PHP formu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "BMI Hesaplayıcı", Aciklama = "Kullanıcıdan boy ve kilo alarak vücut kitle indeksini hesaplayan bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Rastgele Şifre Üretici", Aciklama = "PHP ile rastgele güvenli şifreler üreten bir web uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Ziyaretçi Sayacı", Aciklama = "Sayfa her yenilendiğinde ziyaret sayısını artıran bir PHP uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Basit Alışveriş Listesi", Aciklama = "Kullanıcıların ürün ekleyip listeleyebileceği bir PHP formu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Sıcaklık Dönüştürücü", Aciklama = "Celsius ve Fahrenheit arasında dönüşüm yapan bir PHP uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Renk Seçici", Aciklama = "Kullanıcıdan renk kodu alıp arka planı değiştiren bir PHP sayfası.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Basit Quiz Uygulaması", Aciklama = "Önceden tanımlı sorularla bir bilgi yarışması yapan PHP formu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Haftanın Günü Bulucu", Aciklama = "Girilen tarihe göre haftanın gününü gösteren bir PHP uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Basit Not Hesaplayıcı", Aciklama = "Öğrenci notlarını alıp ortalamayı hesaplayan bir PHP formu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Yemek Tarifi Sayfası", Aciklama = "PHP ile dinamik olarak yemek tariflerini listeleyen bir sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Motivasyon Sözleri", Aciklama = "Rastgele motivasyonel sözler gösteren bir PHP uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Birim Çevirici", Aciklama = "Uzunluk, ağırlık veya hacim birimlerini çeviren bir PHP formu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Basit İletişim Formu", Aciklama = "Kullanıcıdan ad, e-posta ve mesaj alıp ekranda gösteren bir PHP formu.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
konular.Add(new Konu { Baslik = "Dinamik Galeri Sayfası", Aciklama = "PHP ile önceden tanımlı resimleri listeleyen bir galeri sayfası.", Zorluk = Zorluk.Kolay, KategoriId = 8 });
                await Konular.AddRangeAsync(konular);

            }
            
            await SaveChangesAsync();
        }
    }
}
