using Application.DaoInterfaces;
using Domain.DTOs.FullName;
using proto;
using RPCInterface.RPCImplementations;

namespace DataHandling.DAOs;

public class FullNameDao : IFullNameDao
{
    private readonly IRpcBase<FullName> context;

    public FullNameDao(IRpcBase<FullName> context)
    {
        this.context = context;
    }

    public Task<IEnumerable<FullName>> GetAsync(SearchFullNameParametersDto searchParameters)
    {
        IEnumerable<FullName> fullNames = context.Elements.AsEnumerable();
        
        if (!string.IsNullOrEmpty(searchParameters.FirstName))
        {
            fullNames = context.Elements.Where(fullName =>
                fullName.FirstName.Contains(searchParameters.FirstName, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParameters.MiddleName))
        {
            fullNames = context.Elements.Where(fullName =>
                fullName.MiddleName.Contains(searchParameters.MiddleName, StringComparison.OrdinalIgnoreCase));
        }
        
        if (!string.IsNullOrEmpty(searchParameters.LastName))
        {
            fullNames = context.Elements.Where(fullName =>
                fullName.LastName.Contains(searchParameters.LastName, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(fullNames);
    }

    public Task<FullName> CreateAsync(FullName fullName)
    {
        int id = 1;
        if (context.Elements.Any())
        {
            id = context.Elements.Max(i => i.Id);
            id++;
        }

        fullName.Id = id;
        context.Add(fullName);
        return Task.FromResult(fullName);
    }

    public async Task<FullName?> GetFullNameById(int id)
    {
        return await context.GetByIdAsync(id);
    }
}