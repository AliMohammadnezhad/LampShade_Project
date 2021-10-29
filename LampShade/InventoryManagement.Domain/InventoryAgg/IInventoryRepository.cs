using System.Collections.Generic;
using _0_FrameWork.Domain;
using InventoryManagement.Application.Contract.Inventory;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long,Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long id);
        List<InventoryViewModel> Search();
        List<InventoryViewModel> Search(InventorySearchModel searchModel);

    }
}
