using Application.DaoInterfaces;
using Domain.DTOs;
using proto;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class ItemDao : IItemDao
{
    private readonly IRpcBase<Item> context;

    public ItemDao(IRpcBase<Item> context)
    {
        this.context = context;
    }

    public Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters)
    {
        IEnumerable<Item> items = context.Elements.AsEnumerable();

        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            items = context.Elements.Where(item =>
                item.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParameters.ManufactureContains))
        {
            items = context.Elements.Where(item =>
                item.Manufacture.Contains(searchParameters.ManufactureContains, StringComparison.OrdinalIgnoreCase));
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
        
        if (searchParameters.Stock != null)
        {
            items = items.Where(item => item.Stock.Equals(searchParameters.Stock));
        }

        return Task.FromResult(items);
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

    
    //todo what iz this????
    Task<IEnumerable<Item>> IItemDao.GetAsync(SearchItemParametersDto searchParameters)
    {
        return GetAsync(searchParameters);
    }

    //todo same q here
    // Task IItemDao.GetAsync(SearchItemParametersDto searchParameters)
    // {
    //     return GetAsync(searchParameters);
    // }
}