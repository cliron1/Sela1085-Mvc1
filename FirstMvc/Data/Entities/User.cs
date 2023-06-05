using System.ComponentModel.DataAnnotations;

namespace FirstMvc.Data.Entities;

public class User
{
    public int Id { get; set; }

    [Display(Name = "Full Name")]
    [Required]
    public string Name { get; set; }

    [EmailAddress]
    public string Email { get; set; }
    
    public int Age { get; set; }

    public List<Photo> Photos { get; set; }
}
