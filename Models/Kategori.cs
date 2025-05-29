using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GelisimTablosu.Models
{
        public enum Dal
    {
        Yazilim = 0,
        Ag = 1
    }
    public class Kategori
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        public required string Ad { get; set; }

        [Required]
        public Dal Dal { get; set; }
    }
}
