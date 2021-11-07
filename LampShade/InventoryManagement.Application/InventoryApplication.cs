using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;
        private readonly IAuthHelper _authHelper;
        public InventoryApplication(IInventoryRepository inventoryRepository, IAuthHelper authHelper)
        {
            _inventoryRepository = inventoryRepository;
            _authHelper = authHelper;
        }
        public OperationResult Create(CreateInventory command)
        {
            var operationResult = new OperationResult();
            if (_inventoryRepository.Exists(x => x.ProductId == command.ProductId))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            var inventory = new Inventory(command.ProductId, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.Id);
            if (inventory == null) return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_inventoryRepository.Exists(x => x.Id == command.Id && x.ProductId != command.ProductId))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            inventory.Edit(command.ProductId, command.UnitPrice);
            _inventoryRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Increase(IncreaseInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null) return operationResult.Failed(ApplicationMessages.RecordNotFound);
            var operatorId = _authHelper.CurrentAccountId();
            inventory.Increase(command.Count, operatorId, command.Description);
            _inventoryRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Reduce(List<ReduceInventory> command)
        {
            var operationResult = new OperationResult();
            var operatorId = _authHelper.CurrentAccountId();
            foreach (var reduceInventory in command)
            {
                var inventory = _inventoryRepository.GetBy(reduceInventory.ProductId);
                inventory.Reduce(reduceInventory.Count, operatorId, reduceInventory.Description,
                    reduceInventory.OrderId);
            }

            _inventoryRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Reduce(ReduceInventory command)
        {
            var operationResult = new OperationResult();
            var inventory = _inventoryRepository.Get(command.InventoryId);
            if (inventory == null) return operationResult.Failed(ApplicationMessages.RecordNotFound);
            var operatorId = _authHelper.CurrentAccountId();
            inventory.Reduce(command.Count, operatorId, command.Description, operatorId);
            _inventoryRepository.SaveChange();
            return operationResult.Succeed();
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryRepository.GetDetails(id);
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            return searchModel.ProductId > 0 ? _inventoryRepository.Search(searchModel) : _inventoryRepository.Search();
        }

        public List<InventoryOperationsLogViewModel> GetOperationLog(long inventoryId)
        {
            return _inventoryRepository.GetOperationLog(inventoryId);
        }
    }
}
