using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GelisimTablosu.Migrations
{
    /// <inheritdoc />
    public partial class SeedKategoriKonuIfNotExists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kategoriler",
                columns: new[] { "Id", "Ad" },
                values: new object[] { 1, "Python Projeleri" });

            migrationBuilder.InsertData(
                table: "Konular",
                columns: new[] { "Id", "Aciklama", "Baslik", "KategoriId", "Zorluk" },
                values: new object[,]
                {
                    { 1, "Toplama, çıkarma, çarpma, bölme işlemleri yapan basit bir hesap makinesi.", "Hesap Makinesi Uygulaması", 1, 0 },
                    { 2, "Girilen ders notlarına göre ortalama hesaplayıp geçip kalma durumu gösteren uygulama.", "Not Ortalaması Hesaplayıcı", 1, 0 },
                    { 3, "Para çekme, para yatırma, bakiye görüntüleme işlemleri yapılabilir.", "ATM Simülasyonu", 1, 0 },
                    { 4, "Bilgisayarın rastgele tuttuğu sayıyı tahmin etmeye çalışılan oyun.", "Sayı Tahmin Oyunu", 1, 0 },
                    { 5, "Girilen şifrenin uzunluğu ve karakter çeşitliliğine göre zorluk derecesini hesaplar.", "Şifre Güçlülüğü Kontrolü", 1, 0 },
                    { 6, "Boy ve kilo bilgisine göre VKİ değeri ve yorumunu verir.", "Vücut Kitle İndeksi (VKİ) Hesaplayıcı", 1, 0 },
                    { 7, "Kişi ekleme, silme, arama işlemleri yapılabilen telefon rehberi.", "Basit Rehber Uygulaması", 1, 0 },
                    { 8, "İngilizce kelimenin Türkçesini gösteren mini sözlük (hazır bir dictionary yapısı ile).", "Sözlük Uygulaması", 1, 0 },
                    { 9, "5-10 soruluk bir bilgi yarışması. Kullanıcıdan cevap alıp puan hesaplar.", "Yarışma (Quiz) Uygulaması", 1, 0 },
                    { 10, "Kayıtlı kişilerin doğum günlerini saklar ve sorgulama yapılabilir.", "Doğum Günü Hatırlatıcı", 1, 0 },
                    { 11, "1 ile 6 arasında rastgele zar atan uygulama. İstenirse çift zarla yapılabilir.", "Zar Atma Simülatörü", 1, 0 },
                    { 12, "Kullanıcının girdiği sayıya kadar çarpım tablosu oluşturan program.", "Çarpım Tablosu Yazdırıcı", 1, 0 },
                    { 13, "Girilen metni belirli bir kaydırmayla şifreleyen ve çözebilen uygulama.", "Metin Şifreleme (Caesar Cipher)", 1, 0 },
                    { 14, "Kullanıcının girdiği metindeki kelime ve harf sayısını bulur.", "Kelime Sayacı", 1, 0 },
                    { 15, "Kullanıcı bilgilerini .txt dosyasına kaydeder ve okur.", "Dosya Kayıt ve Okuma Uygulaması", 1, 0 },
                    { 16, "Anlık olarak saat/dakika/saniye gösteren mini saat simülasyonu. (Zaman modülü kullanılarak)", "Dijital Saat Gösterimi (Saniyelik)", 1, 0 },
                    { 17, "Ay ve yıl girildiğinde o ayın takvimini gösterir (calendar modülü ile).", "Basit Takvim Görüntüleyici", 1, 0 },
                    { 18, "Girilen aralıkta asal sayıları listeler.", "Asal Sayı Bulucu", 1, 0 },
                    { 19, "Kullanıcının girdiği sayının faktöriyelini hesaplar.", "Faktöriyel Hesaplayıcı", 1, 0 },
                    { 20, "Kullanıcı ürün ekler, siler ve toplam fiyatı gösteren basit bir uygulama.", "Mini Alışveriş Sepeti", 1, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Konular",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Kategoriler",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
