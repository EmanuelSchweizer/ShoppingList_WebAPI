namespace ShoppingList_WebAPI.Models;

public class SharedList
{
    public int Id { get; set; }
    public int ListId { get; set; }
    public int UserId { get; set; }
    
    public User User { get; set; }
    public ShoppingList ShoppingList { get; set; }
}