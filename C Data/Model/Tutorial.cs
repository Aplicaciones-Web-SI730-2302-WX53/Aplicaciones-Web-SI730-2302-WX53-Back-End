namespace Data;

public class Tutorial : Base
{
    public string Title { get; set; }
    public string? Author { get; set; }
    public int? Year { get; set; }
    
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}