using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.DTOs.ListItemDTOs;

namespace ShoppingList_WebAPI.Services.ListItems;

public class ListItemsService(AppDbContext context) : IListItemsService
{
    public Task<List<ListItemResponse>> GetListItemsAsync(int userId, int listId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ListItemResponse> AddListItemAsync(int userId, int listId, AddListItemRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task<ListItemResponse> UpdateItemAsync(int userId, int listId, int itemId, UpdateListItemRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task DeleteItemAsync(int userId, int listId, int itemId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}