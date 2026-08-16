using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ShoppingList_WebAPI.DTOs.RefreshTokenDTOs;
using ShoppingList_WebAPI.DTOs.UserDTOs;
using ShoppingList_WebAPI.Services;
using ShoppingList_WebAPI.Extensions;

namespace ShoppingList_WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService service) : ControllerBase
{
    [HttpPost("signup")]
    public async Task<ActionResult<UserResponse>> SignUp(SignUpUserRequest request, CancellationToken ct = default)
    {
        var response = await service.SignUpAsync(request, ct);
        return Ok(response);
    }
    
    [HttpPost("signIn")]
    public async Task<ActionResult<UserResponse>> SignIn(SignInUserRequest request, CancellationToken ct = default)
    {
        var response = await service.SignInAsync(request, ct);
        return Ok(response);
    }
    
    [HttpPost("resolveUser")]
    [Authorize]
    public async Task<ActionResult<UserResponse>> ResolveUser(CancellationToken ct = default)
    {
        var userId = User.GetUserId();
        var response = await service.ResolveUserAsync(userId, ct);
        return Ok(response);
    }

    [HttpPut("{id}")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult<UserResponse>> UpdateUser(int id, UpdateUserRequest request, CancellationToken ct = default)
    {
        var response = await service.UpdateUserAsync(id, request, ct);
        return Ok(response);
    }

    [HttpPut("{id}/password")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> UpdatePassword(int id, UpdateUserPasswordRequest request, CancellationToken ct = default)
    {
        await service.UpdatePasswordAsync(id, request, ct);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> DeleteUser(int id, CancellationToken ct = default)
    {
        await service.DeleteUserAsync(id, ct);
        return NoContent();
    }

    [EnableRateLimiting(("strict"))]
    [HttpPost("refresh")]
    public async Task<ActionResult<RefreshTokenResponse>> Refresh(RefreshTokenRequest request,
        CancellationToken ct = default)
    {
        var response = await service.RefreshTokenAsync(request, ct);
        return Ok(response);
    }
    
    [HttpPost("logout")]
    public async Task<ActionResult> Logout(RefreshTokenRequest request, CancellationToken ct = default)
    {
        await service.LogoutAsync(request, ct);
        return NoContent();
    }
}