using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GelisimTablosu.Models;

namespace GelisimTablosu.Models
{

    public class Konu
    {
        [Key]

        public int Id { get; set; }

        [Required]
        public required string Baslik { get; set; }
        [Required]
        public required string Aciklama { get; set; }

        

        [Required]
        public Zorluk Zorluk { get; set; }

        [ForeignKey("Kategori")]
        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
    }

    public enum Zorluk
    {
        Kolay = 0,
        Zor = 1
    }

}
