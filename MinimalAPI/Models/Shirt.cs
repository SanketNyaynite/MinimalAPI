using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        [Required]                                  //Model validation using Data Annotations
        public string? Brand { get; set; }
        public int? Size { get; set; }                  //Question to say that size can be null
        [Required]
        public string? Color { get; set; }
        [Required]
        public string? Gender { get; set; }
        public double? Price { get; set; }

    }
}
