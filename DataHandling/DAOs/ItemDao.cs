using Application.DaoInterfaces;
using Domain.DTOs;
using RPCInterface.RPCImplementations;
using RPCInterface.RPCInterfaces;

namespace DataHandling.DAOs;

public class ItemDao : IItemDao
{
    private readonly IRpcBase<Item> context;
    private readonly IRpcFavorite<Favorite> favContext;

    public ItemDao(IRpcBase<Item> context, IRpcFavorite<Favorite> favContext)
    {
        this.context = context;
        this.favContext = favContext;
    }

    public Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters)
    {
        IEnumerable<Item> items = context.Elements.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            items = context.Elements.Where(item =>
                item.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(searchParameters.DescriptionContains))
        {
            items = context.Elements.Where(item =>
                item.Description.Contains(searchParameters.DescriptionContains, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.Price != null)
        {
            items = items.Where(item => item.Price.Equals(searchParameters.Price));
        }

        if (!string.IsNullOrEmpty(searchParameters.ManufacturerContains))
        {
            items = context.Elements.Where(item =>
                item.Manufacturer.Contains(searchParameters.ManufacturerContains, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.Stock != null)
        {
            items = items.Where(item => item.Stock == searchParameters.Stock);
        }

        if (searchParameters.ContainsTags != null && searchParameters.ContainsTags.Any())
        {
            items = items.Where(item => item.Tags.Any(tag => searchParameters.ContainsTags.Contains(tag)));
        }
        
        return Task.FromResult(items);
    }

    public Task<IEnumerable<Item>> GetFavItemsByUserAsync(int userId)
    {
        IEnumerable<Favorite> favList = favContext.Elements.Where(f => f.UserId == userId).ToList();
        IEnumerable<int> itemIds = favList.Select(f => f.ItemId);
        
        IEnumerable<Item> favItems = context.Elements.Where(i => itemIds.Contains(i.Id)).ToList();
        
        return Task.FromResult(favItems);
    }

    public Task<Item> CreateAsync(Item item)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        item.Id = id;

        context.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateAsync(Item item)
    {
        context.Update(item);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        context.Delete(id);
        return Task.CompletedTask;
    }

    public Task<Item?> GetByIdAsync(int id)
    {
        var item = context.Elements.FirstOrDefault(i => i.Id == id);
        return Task.FromResult<Item>(item);
    }
}