using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GelisimTablosu.Models;

namespace GelisimTablosu.Models
{
    public class Student
    {
        [Key]

        public int Id { get; set; }

        [Required]
        public required string Ad { get; set; }
        [Required]
        public required string Sinif { get; set; }
        [Required]
        public Dal Dal { get; set; }
        public string? Isletme { get; set; }
    }
}