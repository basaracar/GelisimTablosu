using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GelisimTablosu.Models
{
    public enum Zorluk
    {
        Kolay = 0,
        Zor = 1
    }

    public class Konu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Baslik { get; set; }
        [Required]
        public string Aciklama { get; set; }

        [Required]
        public Zorluk Zorluk { get; set; }

        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
