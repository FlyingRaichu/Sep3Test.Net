using Domain.DTOs;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Grpc.Net.Client;
using Via.Sep4.Protobuf;

namespace Application.LogicInterfaces;


public interface IItemLogic
{
    Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters);
    Task<Item> CreateAsync(ItemCreationDto dto);
}