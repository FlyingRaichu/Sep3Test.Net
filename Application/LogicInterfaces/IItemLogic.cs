using Domain.DTOs;
using Domain.DTOs.Item;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;

namespace Application.LogicInterfaces;


public interface IItemLogic
{
    Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters);
    Task<Item> CreateAsync(ItemCreationDto dto);
    Task UpdateAsync(ItemUpdateDto dto);
    Task DeleteAsync(int id);

    Task<Item> GetByIdAsync(int id);
}