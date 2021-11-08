using _01_LampShadeQueries.Contracts.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IProductCheckStockStatus _checkStockStatus;

        public InventoryController(IProductCheckStockStatus checkStockStatus)
        {
            _checkStockStatus = checkStockStatus;
        }

        [HttpPost]
        public ProductIsInStockViewModel GetProductStatus(ProductCheckStatusQueryModel model)
        {
            return _checkStockStatus.CheckStockStatusBy(model);
        }
    }
}
