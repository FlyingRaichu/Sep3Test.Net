﻿using Domain.DTOs.Tag;

namespace HttpClients.Implementations;

public interface ITagService
{
    Task<ICollection<Tag>> GetTagsAsync(string? name);
    Task<Tag> CreateAsync(TagCreationDto dto);
    Task UpdateAsync(TagUpdateDto dto);
    Task DeleteAsync(int id);
    Task<Tag> GetByIdAsync(int id);
}