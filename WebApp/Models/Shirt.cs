using System.ComponentModel.DataAnnotations;
using WebApp.Models.Validations;

namespace WebApp.Models
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

        private string? gender;
        [Required]
        public string? Gender { get => gender; set => gender = value?.ToLower(); }
        public double? Price { get; set; }
    }
}
