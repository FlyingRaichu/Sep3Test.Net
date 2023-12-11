using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.DTOs.DiscountCode;


namespace Application.Logic
{
    public class DiscountCodeLogic : IDiscountCodeLogic
    {
        private readonly IDiscountCodeDao discountCodeDao;

        public DiscountCodeLogic(IDiscountCodeDao discountCodeDao)
        {
            this.discountCodeDao = discountCodeDao;
        }
        
        public async Task<DiscountCode> CreateAsync (DiscountCodeDto dto)
        {
            ValidateItem(dto);
            var discountCode = new DiscountCode
            {  
                Code = dto.Code,
                DiscountPercentage = dto.DiscountPercentage,
            };
            
            var created = await discountCodeDao.CreateAsync(discountCode);
            return created;
        }

        public Task<IEnumerable<DiscountCode>> GetAsync(SearchDiscountParametersDto searchParameters)
        {
            return discountCodeDao.GetAsync(searchParameters);
        }
        

        public async Task DeleteAsync(int id)
        {
            await discountCodeDao.DeleteAsync(id);
        }


        private static void ValidateItem(DiscountCodeDto dto)
        {
            if (string.IsNullOrEmpty(dto.Code))
                throw new Exception("Code may not be empty.");

            if (dto.DiscountPercentage < 0)
                throw new Exception("Invalid discount percentage.");
        }
    }
}
