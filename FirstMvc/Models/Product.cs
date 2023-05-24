using System.ComponentModel.DataAnnotations;

namespace FirstMvc.Models;

public class Product {
    public int Id { get; set; }

    [Required(ErrorMessage = "Field is mandatory")]
    [MinLength(3, ErrorMessage = "not long enough")]
    [Display(Name = "Full Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Field is mandatory")]
    [Display(Name = "Final Price")]
    public float? Price { get; set; }

}
