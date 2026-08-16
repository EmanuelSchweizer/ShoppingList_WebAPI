namespace ShoppingList_WebAPI.Models;

public class RefreshToken
{
    public int Id { get; set; }
    public required string TokenHash { get; set; }
    public required int UserId { get; set; }
    public required DateTime ExpiresAt { get; set; }
    public required DateTime CreatedAt { get; set; }
    public DateTime? RevokedAt { get; set; }

    public User User { get; set; } = null!;

    public bool IsActive => RevokedAt == null && ExpiresAt > DateTime.UtcNow;
}