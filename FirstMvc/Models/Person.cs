namespace FirstMvc.Models;

public class Person {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public int Age { get; set; }

    public List<string> Skills { get; set; }
}