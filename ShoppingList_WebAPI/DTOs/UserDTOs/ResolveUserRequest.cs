using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs.UserDTOs;

public class ResolveUserRequest
{
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }
}