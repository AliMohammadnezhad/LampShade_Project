using System;
using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Domain;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : EntityBase
    {
        public long ProductId { get; private set; }
        public double UnitPrice { get; private set; }
        public bool InStock { get; private set; }
        public List<InventoryOperation> Operations { get; set; }
        public Inventory(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            InStock = false;
            CreationDate = DateTime.Now;
        }

        public void Edit(long productId, double unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;

        }

        public long CalculateCurrentStock()
        {
            var plus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            var minus = Operations.Where(x => x.Operation).Sum(x => x.Count);
            return plus - minus;
        }

        public void Increase(long count,long operatorId,string description)
        {
            var currentCount = CalculateCurrentStock() + count;
            var operation = new InventoryOperation(true, count, operatorId, currentCount, description, 0, Id);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Reduce(long count, long operatorId, string description, long orderId)
        {
            var currentCount = CalculateCurrentStock() - count;
            var inventoryOperation = new InventoryOperation(false,count,operatorId,currentCount,description,orderId,Id);
            Operations.Add(inventoryOperation);
            InStock = currentCount > 0;
        }
    }
}


