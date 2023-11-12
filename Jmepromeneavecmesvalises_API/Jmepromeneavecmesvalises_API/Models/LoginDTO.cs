using System.ComponentModel.DataAnnotations;

namespace Jmepromeneavecmesvalises_API.Models;

public class LoginDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}