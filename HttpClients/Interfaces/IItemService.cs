using Domain.DTOs;
using Domain.DTOs.Item;

namespace HttpClients.Implementations;

public interface IItemService
{
    Task<ICollection<Item>> GetItemsAsync(
        string? title,
        string? manufacture,
        string? description,
        double? price);

    Task<Item> CreateAsync(ItemCreationDto dto);
    Task UpdateAsync(ItemUpdateDto dto);
    Task DeleteAsync(int id);
    Task<Item> GetByIdAsync(int id);
}