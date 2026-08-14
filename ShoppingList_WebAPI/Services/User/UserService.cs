using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.DTOs;
using ShoppingList_WebAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
namespace ShoppingList_WebAPI.Services;

public class UserService(AppDbContext context, IConfiguration config) : IUserService
{
    public async Task<SignInUserResponse> SignUpAsync(SignUpUserRequest req, CancellationToken ct)
    {
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email == req.Email, ct);
        
        if(user != null)
            throw new InvalidOperationException("User with the same email already exists");
        
        var role = await context.Roles.FirstOrDefaultAsync(x => x.Name == "user", ct);
        
        if(role == null)
            throw new KeyNotFoundException("Role not found");
        
        var newUser = new User
        {
            Name = req.Name,
            Email = req.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
            RoleId = role.Id,
        };
        context.Users.Add(newUser);
        await context.SaveChangesAsync(ct);
        
        var token = GenerateJwtToken(newUser, role);

        return new SignInUserResponse
        {
            User = new UserResponse
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                RoleId = newUser.RoleId,
                RoleName = role.Name
            },
            Token = token
        };
    }

    public async Task<SignInUserResponse> SignInAsync(SignInUserRequest req, CancellationToken ct)
    {
        var user = await context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Email == req.Email, ct);

        if (user == null || !BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
            throw new UnauthorizedAccessException("Invalid credentials");
        
        var token = GenerateJwtToken(user, user.Role);

        return new SignInUserResponse
        {
            User = new UserResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                RoleId = user.RoleId,
                RoleName = user.Role.Name
            },
            Token = token
        };
    }

    public async Task<UserResponse> ResolveUserAsync(int userId, CancellationToken ct)
    {
        var user = await context.Users
            .Include(x => x.Role)
            .FirstOrDefaultAsync(x => x.Id == userId, ct);
        
        if(user == null)
            throw new KeyNotFoundException("User not found");

        return new UserResponse
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            RoleId = user.RoleId,
            RoleName = user.Role.Name
        };
    }

    public async Task<UserResponse> UpdateUserAsync(int userId, UpdateUserRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task UpdatePasswordAsync(int userId, UpdateUserPasswordRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteUserAsync(int userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
    
    private string GenerateJwtToken(User user, Role role)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var secret = config["Jwt:Secret"];
        if (string.IsNullOrEmpty(secret))
            throw new InvalidOperationException("JWT Secret not configured");
        
        var key = Encoding.ASCII.GetBytes(secret);
    
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role.Name)
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature)
        };
    
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}