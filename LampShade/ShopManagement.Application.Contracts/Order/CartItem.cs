namespace ShopManagement.Application.Contracts.Order
{
    public class CartItem
    {
        public int Id { get; set; }
        public string Picture { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public double UnitPrice { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
        public bool InStock { get; set; }


    }
}
