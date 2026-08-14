using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.DTOs.ListDTOs;

namespace ShoppingList_WebAPI.Services;

public class ShoppingListService(AppDbContext context) : IShoppingListService
{
    public async Task<List<ShoppingListResponse>> GetAllListsAsync(int userId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<ShoppingListResponse> GetListAsync(int userId, int listId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<ShoppingListResponse> CreateListAsync(int userId, CreateShoppingListRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task<ShoppingListResponse> UpdateListAsync(int userId, int listId, UpdateShoppingListRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteListAsync(int userId, int listId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}