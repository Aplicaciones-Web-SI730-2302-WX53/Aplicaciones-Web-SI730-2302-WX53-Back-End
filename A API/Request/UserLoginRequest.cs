using System.ComponentModel.DataAnnotations;

namespace Learnin_center_xw53.Request;

public class UserLoginRequest
{
    [Required]
    public string Username { get; set; }
    
    [Required]
    public string Password { get; set; }
}