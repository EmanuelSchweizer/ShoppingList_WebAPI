using Microsoft.EntityFrameworkCore;


namespace ShoppingList_WebAPI.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{

}