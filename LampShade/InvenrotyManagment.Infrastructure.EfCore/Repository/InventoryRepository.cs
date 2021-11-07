using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.EFCore;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EFCore;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _inventoryContext;
        private readonly ShopContext _shopContext;
        private readonly AccountContext _accountContext;
        public InventoryRepository(InventoryContext context, ShopContext shopContext, AccountContext accountContext) : base(context)
        {
            _shopContext = shopContext;
            _accountContext = accountContext;

            _inventoryContext = context;
        }

        public EditInventory GetDetails(long id)
        {
            return _inventoryContext.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).FirstOrDefault(x => x.Id == id);
        }

        public Inventory GetBy(long id)
        {
            return _inventoryContext.Inventory.FirstOrDefault(x => x.ProductId == id);
        }

        public List<InventoryViewModel> Search()
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                CurrentCount = x.CalculateCurrentStock(),
                InStock = x.InStock,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CreationDate = x.CreationDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();

            query.ForEach(item => item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name);
            return query;
        }

        public List<InventoryViewModel> Search(InventorySearchModel searchModel)
        {
            var products = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var query = _inventoryContext.Inventory.Select(x => new InventoryViewModel
            {
                Id = x.Id,
                CurrentCount = x.CalculateCurrentStock(),
                InStock = x.InStock,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CreationDate = x.CreationDate.ToFarsi()

            }).Where(x => x.ProductId == searchModel.ProductId).OrderByDescending(x=>x.Id).ToList();

            query.ForEach(item =>
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name
            );

            return query;
        }

        public List<InventoryOperationsLogViewModel> GetOperationLog(long inventoryId)
        {
            var operatorNames = _accountContext.Accounts.Select(x => new {x.Id, x.FullName}).ToList();
            var inventory = _inventoryContext.Inventory.FirstOrDefault(x => x.Id == inventoryId);
            var operations = inventory.Operations.Select(x => new InventoryOperationsLogViewModel
            {
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Id = x.Id,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                OrderId = x.OrderId,
                OperatorId = x.OperatorId
            }).OrderByDescending(x => x.Id).ToList();

            operations.ForEach(x => x.Operator = operatorNames.FirstOrDefault(m=>m.Id == x.OperatorId)?.FullName);
            return operations;
        }
    }
}
