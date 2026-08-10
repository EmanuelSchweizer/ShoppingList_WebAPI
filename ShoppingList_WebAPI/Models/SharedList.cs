namespace ShoppingList_WebAPI.Models;

public class SharedList
{
    public int Id { get; set; }
    public int ListId { get; set; }
    public int UserId { get; set; }
    
    public required User User { get; set; }
    public required ShoppingList ShoppingList { get; set; }
}