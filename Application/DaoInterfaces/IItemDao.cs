using Domain.DTOs;
using proto;

namespace Application.DaoInterfaces;

public interface IItemDao
{
    Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters);
    Task<Item> CreateAsync(Item item);
    Task<Item> GetItemByIdAsync(int id);
}