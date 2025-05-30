using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GelisimTablosu.Models;

namespace GelisimTablosu.Models
{

    public class EgitimYili
    {
    [Key]
    public int Id { get; set; }

    public DateTime BaslangicTarihi { get; set; }
    public DateTime BitisTarihi { get; set; }
    public string Ad { get; set; } = string.Empty;    
    }
}