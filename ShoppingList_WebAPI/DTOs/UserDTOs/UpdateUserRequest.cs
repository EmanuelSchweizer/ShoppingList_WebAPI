using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs;

public class UpdateUserRequest
{
    [Required(ErrorMessage = "User name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be 1-100 characters")]
    public required string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "User email is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Email must be 1-100 characters")]
    public required string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "User roleId is required")]
    public required int RoleId { get; set; }
}