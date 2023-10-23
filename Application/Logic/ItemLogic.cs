using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
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

    private static void ValidateItem(ItemCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title) || string.IsNullOrEmpty(dto.Description))
            throw new Exception("Title and description may not be empty.");
        
        if (double.IsNegative(dto.Price) || double.IsInfinity(dto.Price)) throw new Exception("Invalid price.");
    }
}