using System.ComponentModel.DataAnnotations;
using Data;

namespace Learnin_center_xw53.Request;

public class TutorialRequest
{
    [Required]
    public string Title { get; set; }
    [Required]
    [MaxLength(10)]
    public string Author { get; set; }
    
    [Required]
    [Range(1990,2023)]
    public int Year { get; set; }

    public int CategoryId {
        get;
        set;
    }
}