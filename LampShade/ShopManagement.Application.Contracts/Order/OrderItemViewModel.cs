namespace ShopManagement.Application.Contracts.Order
{
    public class OrderItemViewModel
    {
        public long ProductId { get; set; }
        public int Count { get; set; }
        public double UnitPrice { get; set; }
        public int DiscountRate { get; set; }
        public long OrderId { get; set; }
        public string ProductName { get; set; }
    }
}
