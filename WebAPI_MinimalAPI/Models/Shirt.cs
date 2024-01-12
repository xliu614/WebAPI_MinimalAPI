using System.ComponentModel.DataAnnotations;
using WebAPI_MinimalAPI.Models.Validations;

namespace WebAPI_MinimalAPI.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Range(1, 20)]
        [Shirt_EnsureCorrectSize]
        public int? Size { get; set; }
        [Required]
        public string? Gender { get; set; }
        public double? Price { get; set; }
    }
}
