﻿using Domain.DTOs;

namespace Application.DaoInterfaces;

public interface IItemDao
{
    Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters);
    Task<Item> CreateAsync(Item item);
    Task UpdateAsync(Item item);
    Task DeleteAsync(int id);
    Task<Item?> GetByIdAsync(int id);
}