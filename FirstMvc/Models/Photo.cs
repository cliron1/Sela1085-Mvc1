namespace FirstMvc.Models;

public class Photo {
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Path { get; set; }

    //public string Title { get; set; }
    //public string Desc { get; set; }
    //public string Tags { get; set; }

    public List<Comment> Comments { get; set; }
}
