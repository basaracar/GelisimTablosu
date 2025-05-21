using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GelisimTablosu.Models
{
    public class Kategori
    {
        public int Id { get; set; }

        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        public required string Ad { get; set; }
    }
}