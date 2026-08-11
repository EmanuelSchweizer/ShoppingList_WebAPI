using Microsoft.EntityFrameworkCore;
using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.Models;

namespace ShoppingList_WebAPI.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        // Seed Roles
        if (!context.Roles.Any())
        {
            var roles = new[]
            {
                new Role { Name = "user" },
                new Role { Name = "admin" },
                new Role { Name = "demoAdmin" }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();
        }
    
        // Seed Users
        if (!context.Users.Any())
        {
            var demoAdminRole = context.Roles.FirstOrDefault(x => x.Name == "demoAdmin");
            var adminRole = context.Roles.FirstOrDefault(x => x.Name == "admin");
        
            if (demoAdminRole != null && adminRole != null)
            {
                var users = new[]
                {
                    new User
                    {
                        Email = "admin-demo@example.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("demoadmin123"),
                        Name = "demoadmin",
                        RoleId = demoAdminRole.Id
                    },
                    new User
                    {
                        Email = "emanuel.schweizer@icloud.com",
                        Password = BCrypt.Net.BCrypt.HashPassword("admin"),
                        Name = "emanuel",
                        RoleId = adminRole.Id
                    }
                };
            
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
    }
}