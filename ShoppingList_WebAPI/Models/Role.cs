namespace ShoppingList_WebAPI.Models;

public class Role
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<User> Users { get; set; } = new();
}