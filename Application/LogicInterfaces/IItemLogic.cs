using Domain.DTOs;
using Domain.DTOs.Item;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using proto;

namespace Application.LogicInterfaces;


public interface IItemLogic
{
    Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters);
    Task<Item> CreateAsync(ItemCreationDto dto);
}