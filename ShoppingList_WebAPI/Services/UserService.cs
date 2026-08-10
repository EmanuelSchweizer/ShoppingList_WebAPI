using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.DTOs;

namespace ShoppingList_WebAPI.Services;

public class UserService(AppDbContext context) : IUserService
{
    public Task<UserResponse> SignUpAsync(SignUpUserRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> SignInAsync(SignInUserRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponse> ResolveUserAsync(string userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}