namespace ShoppingList_WebAPI.DTOs;

public class SignInUserResponse
{
    public required UserResponse User { get; set; }
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}