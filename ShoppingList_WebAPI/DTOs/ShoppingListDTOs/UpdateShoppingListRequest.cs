using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs.ListDTOs;

public class UpdateShoppingListRequest
{
    [Required(ErrorMessage = "List name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be 1-100 characters")]
    public string Name { get; set; }
}