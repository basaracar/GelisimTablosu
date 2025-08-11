using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GelisimTablosu.Models
{
    public class OgrenciKonuAtama
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student? Student { get; set; }

        [ForeignKey("EgitimYili")]
        public int EgitimYiliId { get; set; }
        public EgitimYili? EgitimYili { get; set; }

        [ForeignKey("Konu")]
        public int KonuId { get; set; }
        public Konu? Konu { get; set; }

  
    }
}
