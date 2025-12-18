using MinimalAPI.Models.Validations;
using System.ComponentModel.DataAnnotations;

namespace MinimalAPI.Models
{
    public class Shirt
    {
        public int ShirtId { get; set; }
        [Required]                //Model validation using Data Annotations. Data Annotations are used on a single property of a model class
        public string? Brand { get; set; }

        //Use Validation attribute like below when there are multiple properties to validate at the same time. In this case we are validating size and gender
        [Shirt_EnsureCorrectSizing]
        public int? Size { get; set; }                  //Question mark to say that size can be null
        [Required]
        public string? Color { get; set; }
        [Required]
        public string? Gender { get; set; }
        public double? Price { get; set; }

    }                                             
}
