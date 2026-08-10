using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs;

public class SignInUserRequest
{
    [Required(ErrorMessage = "User email is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Email must be 1-100 characters")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "User password is required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be 8-100 characters")]
    public string Password { get; set; }
}