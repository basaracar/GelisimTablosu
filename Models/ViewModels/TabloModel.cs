using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GelisimTablosu.Models.ViewModels
{
    public class TableModel
    {

         [Display(Name = "Dal Adı")]
        [Required(ErrorMessage = "Dal adı zorunludur.")]

        public Dal Dal { get; set; }

         [Display(Name = "Adet")]
        public int Adet { get; set; }
    }
}