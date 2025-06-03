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
                Kategoriler.Add(new Kategori {  Ad = "Python Projeleri",Dal = Dal.Yazilim });//1
                Kategoriler.Add(new Kategori {  Ad = "Robotik Kodlama" ,Dal = Dal.Yazilim });//2
                Kategoriler.Add(new Kategori {  Ad = "C# Projeleri" ,Dal = Dal.Yazilim });//3
                Kategoriler.Add(new Kategori { Ad = "Web Tasarım HTML" ,Dal = Dal.Yazilim });//4
                Kategoriler.Add(new Kategori {  Ad = "Mobil Uygulamalar" ,Dal = Dal.Yazilim });//5
              //  Kategoriler.Add(new Kategori {  Ad = "Oyun Geliştirme" });
                Kategoriler.Add(new Kategori {  Ad = "Grafik Tasarım",Dal = Dal.Yazilim  });//6
                Kategoriler.Add(new Kategori {  Ad = "Web Tasarım ASP" ,Dal = Dal.Yazilim });//7
                Kategoriler.Add(new Kategori {  Ad = "Web Tasarım PHP" ,Dal = Dal.Yazilim });//8
                Kategoriler.Add(new Kategori {  Ad = "Ağ Sistemleri Anahtarlama" ,Dal = Dal.Ag});//9

                Kategoriler.Add(new Kategori {  Ad = "Ağ Sistemleri ve Yönlendirme" ,Dal = Dal.Ag});//10
                Kategoriler.Add(new Kategori {  Ad = "Siber Güvenlik Temelleri" ,Dal = Dal.Ag});//11
                Kategoriler.Add(new Kategori {  Ad = "Sunucu İşletim Sistemi" ,Dal = Dal.Ag});//12
                Kategoriler.Add(new Kategori {  Ad = "VLSM Ağ Tasarımı" ,Dal = Dal.Ag});//13
                Kategoriler.Add(new Kategori {  Ad = "Temel Cihaz Yapılandırma" ,Dal = Dal.Ag});//14
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
konular.Add(new Konu { Baslik = "Basit Hesap Makinesi", Aciklama = "Dört temel matematiksel işlemi gerçekleştiren bir mobil hesap makinesi.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Not Tutucu", Aciklama = "Kullanıcıların kısa notlar yazıp görüntüleyebileceği bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Zamanlayıcı Uygulaması", Aciklama = "Geri sayım yapabilen ve alarm çalan basit bir zamanlayıcı.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Rastgele Sayı Üretici", Aciklama = "Belirtilen aralıkta rastgele sayılar üreten bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Metin Okuyucu", Aciklama = "Kullanıcının yazdığı metni sesli okuyan bir metin-konuşma uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Renk Değiştirici", Aciklama = "Butona basıldığında ekranın arka plan rengini değiştiren bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Sayı Tahmin Oyunu", Aciklama = "Kullanıcının rastgele bir sayıyı tahmin etmeye çalıştığı bir oyun.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Basit Çizim Uygulaması", Aciklama = "Dokunmatik ekranda basit çizimler yapmaya olanak tanıyan bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Fener Uygulaması", Aciklama = "Telefonun flaşını açıp kapatan bir el feneri uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Müzik Çalar", Aciklama = "Cihazda yüklü bir ses dosyasını oynatıp durduran basit bir medya oynatıcı.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Hava Durumu Kartı", Aciklama = "Statik veriyle bir şehrin hava durumunu gösteren basit bir ekran.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Egzersiz Sayacı", Aciklama = "Kullanıcının egzersiz tekrarlarını sayan ve gösteren bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Resim Görüntüleyici", Aciklama = "Önceden yüklenmiş resimleri gösteren ve geçiş yapan bir galeri uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Basit Quiz Oyunu", Aciklama = "Önceden tanımlı soruların yer aldığı bir bilgi yarışması uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Döviz Çevirici", Aciklama = "Sabit kurlarla para birimleri arasında dönüşüm yapan bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Alışveriş Listesi", Aciklama = "Kullanıcıların ürün ekleyip listeleyebileceği bir alışveriş listesi uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Kronometre", Aciklama = "Süre ölçen ve başlat/durdur butonları olan bir kronometre uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Motivasyon Sözleri", Aciklama = "Rastgele motivasyonel sözler gösteren bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Telefon Titreşim Uygulaması", Aciklama = "Butona basıldığında telefonun titreşim özelliğini aktive eden bir uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Basit Hesap Defteri", Aciklama = "Gelir ve giderleri kaydedip toplamı gösteren bir finans uygulaması.", Zorluk = Zorluk.Kolay, KategoriId = 5 });
konular.Add(new Konu { Baslik = "Sosyal Medya Gönderi Tasarımı", Aciklama = "Photoshop ile Instagram için dikkat çekici bir kare veya hikaye tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Logo Tasarımı", Aciklama = "Photoshop’ta basit bir marka logosu oluşturma ve vektör benzeri düzenleme.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Etkinlik Afişi", Aciklama = "Photoshop ile bir konser veya seminer için renkli bir afiş tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Fotoğraf Renk Düzenleme", Aciklama = "Photoshop’ta bir fotoğrafın parlaklık, kontrast ve renk tonlarını düzenleme.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Kartvizit Tasarımı", Aciklama = "Photoshop ile profesyonel bir kartvizit şablonu oluşturma.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Davetiye Tasarımı", Aciklama = "Photoshop’ta düğün veya doğum günü için zarif bir davetiye tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Ürün Kapağı Tasarımı", Aciklama = "Photoshop ile bir kitap veya albüm kapağı için görsel düzenleme.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Restoran Menü Tasarımı", Aciklama = "Photoshop’ta yemek kategorileri ve görselleriyle bir menü tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Kolaj Fotoğraf Tasarımı", Aciklama = "Photoshop ile birden fazla fotoğrafı birleştirerek tematik bir kolaj oluşturma.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Tipografi Posteri", Aciklama = "Photoshop’ta yaratıcı metin stilleriyle ilham verici bir poster tasarımı.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Kısa Tanıtım Videosu", Aciklama = "Premiere Pro’da metin ve görsellerle bir ürün veya hizmet tanıtım videosu.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Vlog Videosu Düzenleme", Aciklama = "Premiere Pro’da kısa bir vlog klibini kesip geçiş efektleri ekleme.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Slayt Gösterisi Videosu", Aciklama = "Premiere Pro’da fotoğraflardan müzik eşliğinde bir slayt gösterisi oluşturma.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Eğitim Videosu Tasarımı", Aciklama = "Premiere Pro’da metin ve görsellerle basit bir eğitim videosu düzenleme.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Sosyal Medya Hikaye Videosu", Aciklama = "Premiere Pro’da Instagram hikayeleri için kısa bir animasyonlu video.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Seyahat Videosu Montajı", Aciklama = "Premiere Pro’da seyahat kliplerini birleştirip müzik ve geçiş ekleme.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Etkinlik Teaser Videosu", Aciklama = "Premiere Pro’da bir etkinlik için kısa ve heyecan verici bir teaser videosu.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Fotoğraf Filtre Uygulaması", Aciklama = "Photoshop’ta bir fotoğrafa vintage veya modern filtre efekti uygulama.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "YouTube Thumbnail Tasarımı", Aciklama = "Photoshop ile dikkat çekici bir YouTube video küçük resmi oluşturma.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Video Başlık Animasyonu", Aciklama = "Premiere Pro’da bir videoya basit metin animasyonları ekleme.", Zorluk = Zorluk.Kolay, KategoriId = 6 });
konular.Add(new Konu { Baslik = "Minimalist Saat Tasarımı", Aciklama = "CSS ile stilize edilmiş bir dijital veya analog saat gösteren sayfa.", Zorluk = Zorluk.Kolay, KategoriId = 4 });
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
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir küçük ofis, 192.168.1.0/24 ağını 3 departman için bölmek istiyor: Yönetim (10 host), Satış (20 host), IT (50 host). Görev: VLSM kullanarak her departman için uygun alt ağ maskelerini, ağ adreslerini ve host aralıklarını belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir okul, 172.16.0.0/16 ağını 4 sınıfa bölmek istiyor: Sınıf A (100 host), Sınıf B (60 host), Sınıf C (30 host), Sınıf D (15 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir kafe, 192.168.10.0/24 ağını 2 bölüme ayırmak istiyor: Müşteriler (60 host), Personel (20 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir şirket, 10.0.0.0/8 ağını 8 eşit alt ağa bölmek istiyor. Görev: Yeni alt ağ maskesini ve her alt ağdaki host sayısını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir ev ağı, 192.168.0.0/24 adresini 4 eşit alt ağa bölmek istiyor. Görev: Alt ağ maskesini, her alt ağın ağ adresini ve host sayısını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir şirket, 172.30.0.0/16 ağını 5 departman için bölmek istiyor: HR (200 host), Finans (100 host), Pazarlama (50 host), Destek (30 host), Yönetim (10 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir üniversite, 10.10.0.0/16 ağını 3 bölüme ayırmak istiyor: Kütüphane (500 host), Laboratuvar (200 host), İdari Ofis (50 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir e-ticaret şirketi, 192.168.20.0/24 ağını 2 alt ağa bölmek istiyor: Sunucular (10 host), Çalışanlar (100 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir otel, 192.168.50.0/24 ağını 3 bölüme ayırmak istiyor: Misafir Wi-Fi (120 host), Resepsiyon (30 host), Güvenlik (10 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir fabrika, 172.18.0.0/16 ağını 4 bölüme ayırmak istiyor: Üretim (300 host), Depo (100 host), Ofis (50 host), Yönetim (20 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir hastane, 192.168.100.0/24 ağını 3 bölüme ayırmak istiyor: Poliklinikler (80 host), Acil Servis (40 host), Yönetim (20 host). Görev: VLSM ile alt ağ maskelerini ve host aralıklarını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir havaalanı, 10.1.0.0/16 ağını 4 birime ayırmak istiyor: Güvenlik (150 host), Yolcu Hizmetleri (100 host), Teknik Ekip (60 host), Yönetim (30 host). Görev: VLSM ile uygun alt ağları ve maskeleri belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir yazılım firması, 172.20.0.0/16 ağını 5 departmana bölmek istiyor: Geliştirme (120 host), Test (80 host), IT (50 host), İnsan Kaynakları (20 host), Yönetim (10 host). Görev: VLSM kullanarak her birine uygun alt ağları oluşturun.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir belediye binası, 192.168.200.0/24 ağını 4 alt ağa ayırmak istiyor: Halkla İlişkiler (40 host), Mali Hizmetler (30 host), Zabıta (25 host), Yönetim (10 host). Görev: VLSM ile ağları bölün ve adres aralıklarını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir alışveriş merkezi, 192.168.150.0/24 ağını 3 bölüme ayırmak istiyor: Mağazalar (100 host), Kamera Sistemleri (50 host), Yönetim (20 host). Görev: VLSM ile uygun alt ağları ve maskeleri belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir tren istasyonu, 10.5.0.0/16 ağını 3 bölüme ayırmak istiyor: Bilet Gişeleri (150 host), Güvenlik (100 host), Yönetim (25 host). Görev: VLSM kullanarak alt ağları belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir müzik festivali organizasyonu, 192.168.60.0/24 ağını 4 bölüme ayırmak istiyor: Sahne (80 host), Teknik Ekip (30 host), Sanatçılar (20 host), Yönetim (10 host). Görev: VLSM ile alt ağlara ayırın ve adres aralıklarını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir araştırma laboratuvarı, 172.31.0.0/16 ağını 4 alt ağa bölmek istiyor: Genetik Birimi (200 host), Biyokimya (100 host), IT (60 host), İdari Ofis (15 host). Görev: VLSM ile ağları planlayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir medya ajansı, 192.168.70.0/24 ağını 3 departmana bölmek istiyor: Video Prodüksiyon (60 host), Grafik Tasarım (30 host), İdari Ofis (10 host). Görev: VLSM kullanarak uygun ağları oluşturun.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Alt Ağlara Bölme", Aciklama = "Durum: Bir kamu kurumu, 10.2.0.0/16 ağını 6 bölüme ayırmak istiyor: Arşiv (300 host), Teknik Servis (150 host), Bilgi İşlem (80 host), Personel (60 host), Halkla İlişkiler (40 host), Yönetim (20 host). Görev: VLSM kullanarak her bölüm için ağ maskesi ve adres aralıklarını hesaplayın.", Zorluk = Zorluk.Kolay, KategoriId = 13 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir küçük ofiste yeni bir 24 portlu anahtar kuruldu. Anahtar, ofis ağını yönetmek için kullanılacak. Görev: Komut arayüzü üzerinden anahtarın hostname'ini 'Office-Switch' olarak ayarlayın, yönetici şifresini yapılandırın ve konsol erişimini güvenli hale getirmek için bir parola belirleyin.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir okulun bilgisayar laboratuvarında 16 portlu bir anahtar kullanılıyor. Laboratuvardaki 10 bilgisayar aynı VLAN'da olmalı. Görev: Komut arayüzü üzerinden VLAN 10 oluşturun, VLAN'a 'Lab-VLAN' adını verin ve 1-10 numaralı portları bu VLAN'a atayın.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir kafe, müşteri Wi-Fi ağı için bir anahtara bağlı bir erişim noktası kullanıyor. Anahtar, yönetim için bir IP adresine ihtiyaç duyuyor. Görev: Komut arayüzü üzerinden anahtara VLAN 1 üzerinde 192.168.1.10/24 IP adresini atayın ve varsayılan ağ geçidini 192.168.1.1 olarak ayarlayın.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir e-ticaret şirketinde 24 portlu bir anahtar, sunucular ve çalışan cihazları için kullanılıyor. Güvenlik için kullanılmayan portlar kapatılmalı. Görev: Komut arayüzü üzerinden 20-24 numaralı portları devre dışı bırakın ve anahtarın hostname'ini 'Server-Switch' olarak ayarlayın.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir ev ağında 8 portlu bir anahtar, medya cihazlarını bağlamak için kullanılıyor. Anahtar, uzaktan yönetim için yapılandırılacak. Görev: Komut arayüzü üzerinden anahtara VLAN 1 üzerinde 192.168.0.100/24 IP adresini atayın ve Telnet erişimini etkinleştirin.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir hastanede 24 portlu bir anahtar, tıbbi cihazlar ve bilgisayarlar için kullanılıyor. Tıbbi cihazlar ayrı bir VLAN'da olmalı. Görev: Komut arayüzü üzerinden VLAN 20 oluşturun, VLAN'a 'Medical-VLAN' adını verin ve 1-5 numaralı portları bu VLAN'a atayın.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir üniversite kütüphanesinde iki 16 portlu anahtar kullanılıyor. Anahtarlar birbirine bağlanacak ve yönetim için yapılandırılacak. Görev: Komut arayüzü üzerinden birinci anahtarın hostname'ini 'Lib-Switch1' olarak ayarlayın ve 16 numaralı portu başka bir anahtara bağlanmak için trunk port olarak yapılandırın.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir fabrikada 24 portlu bir anahtar, üretim cihazları için kullanılıyor. Güvenlik için yalnızca belirli portlar aktif olmalı. Görev: Komut arayüzü üzerinden 1-12 numaralı portları erişim portu olarak yapılandırın, VLAN 30'a atayın ve diğer portları devre dışı bırakın.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir otel lobisinde 16 portlu bir PoE anahtar, IP telefonlar ve Wi-Fi AP'ler için kullanılıyor. Yönetim için anahtar yapılandırılacak. Görev: Komut arayüzü üzerinden anahtara VLAN 1 üzerinde 192.168.50.5/24 IP adresini atayın ve SSH erişimini etkinleştirin.", Zorluk = Zorluk.Kolay, KategoriId = 14 });
konular.Add(new Konu { Baslik = "Temel Anahtar Yapılandırması", Aciklama = "Durum: Bir spor salonunda 12 portlu bir anahtar, akıllı TV'ler ve bilgisayarlar için kullanılıyor. Cihazlar iki farklı VLAN'da olmalı. Görev: Komut arayüzü üzerinden VLAN 10 ('TV-VLAN') ve VLAN 20 ('PC-VLAN') oluşturun, 1-6 portları VLAN 10'a, 7-12 portları VLAN 20'ye atayın.", Zorluk = Zorluk.Kolay, KategoriId = 14 });             
        konular.Add(new Konu {
    Baslik = "Statik Yönlendirme ile 3 Ağa Erişim",
    Aciklama = "Durum: Üç farklı LAN ağına sahip küçük bir firma, bu ağları birbirine yönlendirmek istiyor. Router'lar arasında sadece statik yönlendirme kullanılacak. Görev: Her bir router’da gerekli yönlendirme komutlarını yapılandırın ve ağlar arası iletişimi sağlayın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Farklı Alt Ağlar Arası Statik Yönlendirme",
    Aciklama = "Durum: 192.168.1.0/24 ve 192.168.2.0/24 olmak üzere iki farklı LAN, iki farklı router ile bağlanmıştır. Görev: Statik yönlendirme yapılandırarak ağlar arası ping başarısı sağlayın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Statik Yönlendirme ile Yıldız Topoloji",
    Aciklama = "Durum: Merkezde bir router ve ona bağlı 3 farklı şube router’ı var. Şubelerde 3 farklı LAN ağı bulunuyor. Görev: Statik yönlendirme kullanarak merkezden tüm şubelere ulaşımı sağlayın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Yedekli Statik Yönlendirme (Floating Routes)",
    Aciklama = "Durum: Bir kurum, iki router arasında ana bağlantı ve yedek bağlantı olmak üzere iki yol yapılandırmak istiyor. Görev: Primary ve backup route olacak şekilde statik yönlendirme yapın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "2 Router, 3 Ağ: Statik Route ile İletişim",
    Aciklama = "Durum: Router A'ya bağlı 192.168.10.0/24 ağı, Router B'ye bağlı 192.168.20.0/24 ve 192.168.30.0/24 ağları bulunuyor. Görev: Router A'dan diğer iki ağa erişim için yönlendirme yapılandırması yapın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Statik Yönlendirme ile Default Route Kullanımı",
    Aciklama = "Durum: Bir LAN sadece internete çıkış için bir yönlendirme yapmak istiyor. Görev: Varsayılan yön (default route) tanımlayarak yönlendirmeyi sağlayın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Statik Yönlendirme ile Küçük Ofis Ağı",
    Aciklama = "Durum: Ofiste iki router ve üç farklı ağ bulunmakta. Router'lar sadece statik yönlendirme kullanabiliyor. Görev: PC'lerin tüm ağlarla iletişim kurabilmesi için yönlendirme yapılandırması yapın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Statik Yönlendirme ile İntranet Erişimi",
    Aciklama = "Durum: Merkez ofis ile 2 farklı şube ofisi arasında özel bir intranet bağlantısı kurmak isteniyor. Görev: Tüm router’lara gerekli yönlendirme bilgilerini statik olarak girin.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Statik ve Default Route Birlikte Kullanımı",
    Aciklama = "Durum: Router A, 2 yerel ağa doğrudan bağlı. İnternet erişimi ise Router B üzerinden sağlanıyor. Görev: Router A’ya bağlı yerel ağlar için statik, internete çıkış için default route yapılandırın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});

konular.Add(new Konu {
    Baslik = "Statik Yönlendirme ile Bölge Bağlantısı",
    Aciklama = "Durum: Bir kamu kuruluşunun üç bölge müdürlüğü kendi LAN’larına sahip. Tüm bölgelerin kendi arasında iletişim kurması isteniyor. Görev: Router’larda statik yönlendirme yapılandırması yaparak iletişimi sağlayın.",
    Zorluk = Zorluk.Kolay,
    KategoriId = 14
});
       
               
                await Konular.AddRangeAsync(konular);

            }
            
            await SaveChangesAsync();
        }
    }
}
