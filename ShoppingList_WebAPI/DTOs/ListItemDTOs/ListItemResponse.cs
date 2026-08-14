namespace ShoppingList_WebAPI.DTOs.ListItemDTOs;

public class ListItemResponse
{
    public int Id { get; set; }
    public required string Name  { get; set; }
    public bool Bought { get; set; } = false;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int ListId { get; set; }
}