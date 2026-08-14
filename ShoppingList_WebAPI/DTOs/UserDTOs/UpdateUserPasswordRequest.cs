using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs;

public class UpdateUserPasswordRequest
{
    [Required(ErrorMessage = "New password is required")]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be 8-100 characters")]
    [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).+$",
        ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character")]
    public required string NewPassword { get; set; }
}