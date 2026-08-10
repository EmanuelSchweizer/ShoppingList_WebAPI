namespace ShoppingList_WebAPI.DTOs;

public class SignInUserResponse
{
    public UserResponse User { get; set; }
    public string Token { get; set; }
}