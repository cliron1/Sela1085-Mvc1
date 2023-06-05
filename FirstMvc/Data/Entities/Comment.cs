namespace FirstMvc.Data.Entities;

public class Comment
{
    public int Id { get; set; }
    public int PhotoId { get; set; }
    public string Text { get; set; }
}
