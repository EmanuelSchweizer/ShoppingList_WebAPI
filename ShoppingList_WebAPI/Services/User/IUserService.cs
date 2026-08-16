using ShoppingList_WebAPI.DTOs.UserDTOs;
using ShoppingList_WebAPI.DTOs.RefreshTokenDTOs;

namespace ShoppingList_WebAPI.Services;

public interface IUserService
{
    Task<SignInUserResponse> SignUpAsync(SignUpUserRequest req, CancellationToken ct);
    Task<SignInUserResponse> SignInAsync(SignInUserRequest req, CancellationToken ct);
    Task<UserResponse> ResolveUserAsync(int userId, CancellationToken ct);
    Task<UserResponse> UpdateUserAsync(int userId, UpdateUserRequest req, CancellationToken ct);
    Task UpdatePasswordAsync(int userId, UpdateUserPasswordRequest req , CancellationToken ct);
    Task DeleteUserAsync(int userId, CancellationToken ct);
    Task<RefreshTokenResponse> RefreshTokenAsync(RefreshTokenRequest req, CancellationToken ct);
    Task LogoutAsync(RefreshTokenRequest req, CancellationToken ct);
}