using System.Linq;
using _01_LampShadeQueries.Contracts.Inventory;
using InventoryManagement.Infrastructure.EfCore;

namespace _01_LampShadeQueries.Queries
{
    public class ProductCheckStockStatus:IProductCheckStockStatus
    {
        private readonly InventoryContext _context;

        public ProductCheckStockStatus(InventoryContext context)
        {
            _context = context;
        }

        public ProductIsInStockViewModel CheckStockStatusBy(ProductCheckStatusQueryModel model)
        {
            var queryModel = new ProductIsInStockViewModel();
            var inventory = _context.Inventory.FirstOrDefault(x => x.ProductId == model.ProductID);
            if (inventory != null && inventory.CalculateCurrentStock() > model.Count)
            {
                queryModel.IsInStock = true;
            }
            else
            {
                queryModel.IsInStock = false;

            }

            return queryModel;
        }
    }
}
