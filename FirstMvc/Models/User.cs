using System.ComponentModel.DataAnnotations;

namespace FirstMvc.Models;

public class User {
    public int Id { get; set; }

    [Display(Name="Full Name")]
    [Required]
    public string Name { get; set; }

    public List<Photo> Photos { get; set; }
}
