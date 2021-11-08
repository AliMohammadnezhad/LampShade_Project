namespace _01_LampShadeQueries.Contracts.Inventory
{
    public interface IProductCheckStockStatus
    {
        ProductIsInStockViewModel CheckStockStatusBy(ProductCheckStatusQueryModel model);
    }
}
