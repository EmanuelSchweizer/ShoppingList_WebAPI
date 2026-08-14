namespace ShoppingList_WebAPI.Models;

public class ShoppingList
{
    public int Id  { get; set; }
    public required string Name { get; set; }
    public required DateTime CreatedAt { get; set; }
    public required DateTime UpdatedAt { get; set; }
    public required int OwnerId { get; set; }
    
    public User Owner { get; set; }
    public List<SharedList> SharedWith { get; set; } = new();
    public List<ListItem> Items { get; set; } = new();
}