using Domain.DTOs;
using Domain.DTOs.Item;

namespace HttpClients.Interfaces;

public interface IItemService
{
    Task<ICollection<Item>> GetItemsAsync(
        string? title,
        string? description,
        double? price,
        string? manufacturer,
        int? stock, 
        List<int>? tags,
        double? discountPercentage);

    Task<ICollection<Item>> GetFavItemsByUserId(int id, string token);

    Task<Item> CreateAsync(ItemCreationDto dto);
    Task UpdateAsync(ItemUpdateDto dto);
    Task DeleteAsync(int id);
    Task<Item> GetByIdAsync(int id);
}