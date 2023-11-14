using System.ComponentModel;

namespace Data;

public class Category : Base
{
    public string? Name { get; set; }
    public string? LongDescription { get; set; }
    
    public List<Tutorial> Tutorials { get; set; }
}