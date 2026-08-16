namespace ShoppingList_WebAPI.DTOs.RefreshTokenDTOs;

public class RefreshTokenResponse
{
    public required string Token { get; set; }
    public required string RefreshToken { get; set; }
}