using System.ComponentModel.DataAnnotations;

namespace FirstMvc.Data.Views;

public class VUser {
    public int Id { get; set; }

    [Display(Name = "Full Name")]
    public string Name { get; set; }

    public int Cnt { get; set; }
}
