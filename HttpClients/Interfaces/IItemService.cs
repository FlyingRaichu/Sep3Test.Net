using Domain.DTOs;
using Domain.DTOs.Item;

namespace HttpClients.Implementations;

public interface IItemService
{
    Task<ICollection<Item>> GetPostsAsync(
        string? title,
        string? description,
        double? price);

    Task<Item> CreateAsync(ItemCreationDto dto);
}