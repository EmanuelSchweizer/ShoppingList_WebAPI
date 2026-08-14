using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs.SharedListDTOs;

public class SharedListRequest
{
    [Required(ErrorMessage = "User email is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Email must be 1-100 characters")]
    public string Email { get; set; }
}