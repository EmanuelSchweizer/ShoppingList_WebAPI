using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs.UserDTOs;

public class SignUpUserRequest
{
    [Required(ErrorMessage = "User name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be 1-100 characters")]
    public string Name { get; set; }

    [Required(ErrorMessage = "User email is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Email must be 1-100 characters")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "User password is required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be 8-100 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&.])[A-Za-z\d@$!%*?&.]{8,}$", 
        ErrorMessage = "Password must contain uppercase, lowercase, number and special character")]
    public string Password { get; set; }
}