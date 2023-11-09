using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.DTOs.Item;
using Via.Sep4.Protobuf;

namespace Application.Logic;

public class ItemLogic : IItemLogic
{
    private readonly IItemDao itemDao;

    public ItemLogic(IItemDao itemDao)
    {
        this.itemDao = itemDao;
    }


    public Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters)
    {
        return itemDao.GetAsync(searchParameters);
    }

    public async Task<Item> CreateAsync(ItemCreationDto dto)
    {
        ValidateItem(dto);
        var item = new Item
        {
            Title = dto.Title,
            Description = dto.Description,
            Price = dto.Price
        };
        var created = await itemDao.CreateAsync(item);
        return created;
    }

    public async Task UpdateAsync(ItemUpdateDto dto)
    {
        var existing = await GetByIdAsync(dto.Id);

        string titleToUse = dto.Title ?? existing.Title;
        string descriptionToUse = dto.Description ?? existing.Description;
        double priceToUse = dto.Price ?? existing.Price;

        Item updated = new()
        {
            Id = existing.Id,
            Title = titleToUse,
            Description = descriptionToUse,
            Price = priceToUse
        };
        
        ValidateItem(updated);
        await itemDao.UpdateAsync(updated);
    }

    public async Task DeleteAsync(int id)
    {

        await itemDao.DeleteAsync(id);
    }

    public async Task<Item> GetByIdAsync(int id)
    {
        Item? item = await itemDao.GetByIdAsync(id);

        if (item == null)
        {
            throw new Exception($"Item with Id {id} does not exist.");
        }

        return item;
    }
    
    private static void ValidateItem(ItemCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title) || string.IsNullOrEmpty(dto.Description))
            throw new Exception("Title and description may not be empty.");
        
        if (double.IsNegative(dto.Price) || double.IsInfinity(dto.Price)) throw new Exception("Invalid price.");
    }

    private static void ValidateItem(Item item)
    {
        if (string.IsNullOrEmpty(item.Title) || string.IsNullOrEmpty(item.Description))
            throw new Exception("Title and description may not be empty.");
        
        if (double.IsNegative(item.Price) || double.IsInfinity(item.Price)) throw new Exception("Invalid price.");
    }
}