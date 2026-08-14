using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs.ListItemDTOs;

public class AddListItemRequest
{
    [Required(ErrorMessage = "ListItem name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be 1-100 characters")]
    public required string Name  { get; set; }
}