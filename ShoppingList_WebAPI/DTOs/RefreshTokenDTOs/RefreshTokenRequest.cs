using System.ComponentModel.DataAnnotations;

namespace ShoppingList_WebAPI.DTOs.RefreshTokenDTOs;

public class RefreshTokenRequest
{
    [Required(ErrorMessage = "Refresh token is required")]
    public required string RefreshToken { get; set; }
}