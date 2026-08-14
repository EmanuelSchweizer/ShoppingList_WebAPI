using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.DTOs.SharedListDTOs;

namespace ShoppingList_WebAPI.Services.SharedLists;

public class SharedListService(AppDbContext context) : ISharedListService
{
    public Task ShareListAsync(int ownerId, int listId, SharedListRequest req, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    public Task UnShareListAsync(int ownerId, int listId, int sharedUserId, CancellationToken ct)
    {
        throw new NotImplementedException();
    }
}