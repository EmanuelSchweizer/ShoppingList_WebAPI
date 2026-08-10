using ShoppingList_WebAPI.DTOs;
namespace ShoppingList_WebAPI.Services;

public interface IUserService
{
    Task<UserResponse> SignUpAsync(SignUpUserRequest req, CancellationToken ct);
    Task<UserResponse> SignInAsync(SignInUserRequest req, CancellationToken ct);
    Task<UserResponse> ResolveUserAsync(string userId, CancellationToken ct);
}