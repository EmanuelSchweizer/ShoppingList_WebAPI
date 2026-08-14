using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs.ListItemDTOs;

public class UpdateListItemRequest
{
    [Required(ErrorMessage = "ListItem name is required")]
    [StringLength(100, MinimumLength = 1, ErrorMessage = "Name must be 1-100 characters")]
    public required string Name  { get; set; }
    
    [Required(ErrorMessage = "ListItem bought is required")]
    public bool Bought { get; set; } = false;
}