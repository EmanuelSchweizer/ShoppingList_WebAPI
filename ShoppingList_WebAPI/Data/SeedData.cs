using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.Models;

namespace ShoppingList_WebAPI.Data;

public static class SeedData
{
    public static void Initialize(AppDbContext context)
    {
        if (context.Roles.Any())
            return;

        var roles = new[]
        {
            new Role { Name = "user" },
            new Role { Name = "admin" },
            new Role { Name = "demoAdmin" }
        };

        context.Roles.AddRange(roles);
        context.SaveChanges();
    }
}