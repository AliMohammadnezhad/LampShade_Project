using System.Collections.Generic;
using _0_FrameWork.Application;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        OperationResult Increase(IncreaseInventory command);
        OperationResult Reduce(List<ReduceInventory> command);
        OperationResult Reduce(ReduceInventory command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
    }
}
