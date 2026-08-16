namespace ShoppingList_WebAPI.Models;

public class User
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public required string Email { get; set; } = string.Empty;
    public required string Password { get; set; } = string.Empty;
    public required int RoleId { get; set; }
    
    public Role Role { get; set; }
    public List<ShoppingList> OwnedLists { get; set; } = new();
    public List<SharedList> SharedLists { get; set; } = new();
    public List<RefreshToken> RefreshTokens { get; set; } = new();
} 