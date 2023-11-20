using Application.DaoInterfaces;
using Domain.DTOs;
using RPCInterface.RPCImplementations;
using Via.Sep4.Protobuf;

namespace DataHandling.DAOs
{
    public class ItemDao : IItemDao
    {
        private readonly IRpcBase<Item> context;

        public ItemDao(IRpcBase<Item> context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Item>> GetAsync(SearchItemParametersDto searchParameters)
        {
            IEnumerable<Item> items = context.Elements.AsEnumerable();

            if (!string.IsNullOrEmpty(searchParameters.TitleContains))
            {
                items = items.Where(item =>
                    item.Title.Contains(searchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchParameters.ManufactureContains))
            {
                items = items.Where(item =>
                    item.Manufacture.Contains(searchParameters.ManufactureContains, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrEmpty(searchParameters.DescriptionContains))
            {
                items = items.Where(item =>
                    item.Description.Contains(searchParameters.DescriptionContains, StringComparison.OrdinalIgnoreCase));
            }

            if (searchParameters.Price != null)
            {
                items = items.Where(item => item.Price.Equals(searchParameters.Price.Value));
            }

            if (searchParameters.Stock != null)
            {
                items = items.Where(item => item.Stock.Equals(searchParameters.Stock.Value));
            }

            return items.ToList(); // Execute the query and return the result
        }

        public async Task<Item> CreateAsync(Item item)
        {
            int id = 1;
            if (context.Elements.Any())
            {
                id = context.Elements.Max(i => i.Id);
                id++;
            }

            item.Id = id;

            context.Add(item);
            return item;
        }

        public async Task UpdateAsync(Item item)
        {
            context.Update(item);
        }

        public async Task DeleteAsync(int id)
        {
            context.Delete(id);
        }

        public async Task<Item?> GetByIdAsync(int id)
        {
            var item = context.Elements.FirstOrDefault(i => i.Id == id);
            return item;
        }
    }
}
