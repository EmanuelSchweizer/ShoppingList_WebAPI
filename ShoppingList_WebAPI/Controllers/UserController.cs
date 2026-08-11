using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingList_WebAPI.DTOs;
using ShoppingList_WebAPI.Services;

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
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("Invalid token");

        var response = await service.ResolveUserAsync(userId, ct);
        return Ok(response);
    }
}