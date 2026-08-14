using Microsoft.EntityFrameworkCore;
using ShoppingList_WebAPI.Data;
using ShoppingList_WebAPI.DTOs.ListItemDTOs;
using ShoppingList_WebAPI.Models;

namespace ShoppingList_WebAPI.Services.ListItems;

public class ListItemsService(AppDbContext context) : IListItemsService
{
    public async Task<List<ListItemResponse>> GetListItemsAsync(int userId, int listId, CancellationToken ct)
    {
        var listExists = await context.ShoppingLists
            .AnyAsync(x => x.Id == listId && x.OwnerId == userId, ct);
    
        if (!listExists)
            throw new KeyNotFoundException("List not found");
        
        var items = await context.ListItems
            .Where(x => x.ListId == listId && x.ShoppingList.OwnerId == userId)
            .Select(x => new ListItemResponse
            {
                Id = x.Id,
                Name = x.Name,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt,
                Bought = x.Bought
            }).ToListAsync(ct);

        return items;
    }

    public async Task<ListItemResponse> AddListItemAsync(int userId, int listId, AddListItemRequest req, CancellationToken ct)
    {
        var existingList = await context.ShoppingLists.AnyAsync(x => x.OwnerId == userId && x.Id == listId, ct);
        
        if (!existingList)
            throw new KeyNotFoundException("List not found");

        var newItem = new ListItem
        {
            Name = req.Name,
            ListId = listId,
            UpdatedAt = DateTime.UtcNow,
            CreatedAt = DateTime.UtcNow,
            Bought = false
        };
        
        await context.ListItems.AddAsync(newItem, ct);
        await context.SaveChangesAsync(ct);

        return new ListItemResponse
        {
            Id = newItem.Id,
            Name = newItem.Name,
            Bought = newItem.Bought,
            UpdatedAt = newItem.UpdatedAt,
            CreatedAt = newItem.CreatedAt,
            ListId = newItem.ListId
        };
    }

    public async Task<ListItemResponse> UpdateItemAsync(int userId, int listId, int itemId, UpdateListItemRequest req, CancellationToken ct)
    {
        var item = await context.ListItems
            .Where(x => x.ShoppingList.OwnerId == userId && x.ListId == listId && x.Id == itemId)
            .FirstOrDefaultAsync(ct);
        
        if (item == null)
            throw new KeyNotFoundException("Item not found");
        
        item.Name = req.Name;
        item.UpdatedAt = DateTime.UtcNow;
        item.Bought = req.Bought;
        
        await context.SaveChangesAsync(ct);

        return new ListItemResponse
        {
            Id = item.Id,
            Name = item.Name,
            Bought = item.Bought,
            UpdatedAt = item.UpdatedAt,
            CreatedAt = item.CreatedAt,
            ListId = item.ListId
        };
    }

    public async Task DeleteItemAsync(int userId, int listId, int itemId, CancellationToken ct)
    {
        var item = await context.ListItems
            .Where(x => x.ShoppingList.OwnerId == userId && x.ListId == listId && x.Id == itemId)
            .FirstOrDefaultAsync(ct);
        
        if (item == null)
            throw new KeyNotFoundException("Item not found");
        
        context.ListItems.Remove(item);
        await context.SaveChangesAsync(ct);
    }
}