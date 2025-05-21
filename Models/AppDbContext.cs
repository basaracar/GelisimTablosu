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
    }


}
