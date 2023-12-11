using Application.DaoInterfaces;
using Domain.DTOs.DiscountCode;
using RPCInterface.RPCInterfaces;

namespace DataHandling.DAOs;

public class DiscountCodeDao : IDiscountCodeDao
{
    private readonly IRpcDiscountCode<DiscountCode> dbContext;

    public DiscountCodeDao(IRpcDiscountCode<DiscountCode> dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public Task<DiscountCode> CreateAsync(DiscountCode request)
    {
        int id = 1;
        if (dbContext.Elements.Any())
        {
            id = dbContext.Elements.Max(i => i.Id);
            id++;
        }

        request.Id = id;

        dbContext.Add(request);
        return Task.FromResult(request);
    }

    public Task DeleteAsync(int id)
    {
        dbContext.Delete(id);
        return Task.CompletedTask;
    }

    public Task<IEnumerable<DiscountCode>> GetAsync(SearchDiscountParametersDto searchParameters)
    {
        IEnumerable<DiscountCode> discountCodes = dbContext.Elements.AsEnumerable();
        
        if (!string.IsNullOrEmpty(searchParameters.CodeContains))
        {
            discountCodes = dbContext.Elements.Where(code =>
                code.Code.Contains(searchParameters.CodeContains, StringComparison.OrdinalIgnoreCase));
        }

        if (searchParameters.DiscountPercentageContains != null)
        {
            discountCodes = discountCodes.Where(code =>
                code.DiscountPercentage == searchParameters.DiscountPercentageContains);
        }

        return Task.FromResult(discountCodes);
    }
}
