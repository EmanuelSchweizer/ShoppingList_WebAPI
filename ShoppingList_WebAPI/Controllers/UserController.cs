using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList_WebAPI.DTOs;
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

    [HttpPut("updateUser")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult<UserResponse>> UpdateUser(UpdateUserRequest request, CancellationToken ct = default)
    {
        var userId = User.GetUserId();
        var response = await service.UpdateUserAsync(userId, request, ct);
        return Ok(response);
    }

    [HttpPut("updatePassword")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> UpdatePassword(UpdateUserPasswordRequest request,
        CancellationToken ct = default)
    {
        var userId = User.GetUserId();
        await service.UpdatePasswordAsync(userId, request, ct);
        return NoContent();
    }

    [HttpDelete("deleteUser")]
    [Authorize(Policy = "RequireAdmin")]
    public async Task<ActionResult> DeleteUser(CancellationToken ct = default)
    {
        var userId = User.GetUserId();
        await  service.DeleteUserAsync(userId, ct);
        return NoContent();
    }
}