using Microsoft.EntityFrameworkCore;
using GelisimTablosu.Models;
using System.Text.Json;

namespace GelisimTablosu.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Konu> Konular { get; set; }
        public DbSet<EgitimYili> EgitimYillari { get; set; }
        public DbSet<Takvim> Takvimler { get; set; }

        public DbSet<Student> Students { get; set; }


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
                var json = File.ReadAllText("Data/Kategoriler.json");
                var kategoriler = JsonSerializer.Deserialize<List<Kategori>>(json);
                await Kategoriler.AddRangeAsync(kategoriler);
                await SaveChangesAsync();
            }
        }
        public async Task SeedKonu()
        {
            if (!Konular.Any())
            {
                var json = File.ReadAllText("Data/Konular.json");
                var konular = JsonSerializer.Deserialize<List<Konu>>(json);
                await Konular.AddRangeAsync(konular);
                await SaveChangesAsync();
            }
            if (!EgitimYillari.Any())
            {
                var egitimYili = new EgitimYili
                {
                    Ad = "2025-2026 Eğitim Öğretim Yılı",
                    BaslangicTarihi = new DateTime(2025, 9, 6),
                    BitisTarihi = new DateTime(2026, 6, 26)
                };
                await EgitimYillari.AddAsync(egitimYili);
                await SaveChangesAsync();
            }
        }
    }
}
