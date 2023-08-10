

using System.ComponentModel.DataAnnotations;

namespace parafia_mbkm.data.Models;

public class RegistrationRequest
{
    [Required]
    public string Email { get; set; } = null!;
    [Required] 
    public string Password { get; set; } = null!;
    [Required] 
    public string UserName { get; set; } = null!;
}
