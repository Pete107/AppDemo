using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoreLibrary.DataTransfer;

public class LoginModel
{
    [Required]
    public string Username { get; set; } = string.Empty;
    [Required, PasswordPropertyText]
    public string Password { get; set; } = string.Empty;
}