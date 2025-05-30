using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GelisimTablosu.Models;

namespace GelisimTablosu.Models
{

    public class Takvim
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Hafta { get; set; }   

        [ForeignKey("EgitimYili")]
        public int EgitimYiliId { get; set; }
        public EgitimYili? EgitimYili { get; set; }
     
     }
}