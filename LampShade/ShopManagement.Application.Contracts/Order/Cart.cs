using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public class Cart
    {
        public double DiscountAmount { get; set; }
        public double TotalAmount { get; set; }
        public int DiscountRate { get; set; }
        public double CartForPayAmount { get; set; }
        public List<CartItem> CartItems { get; set; }

        public Cart()
        {
            CartItems = new List<CartItem>();
        }
        public void Add(CartItem item)
        {
            DiscountAmount += item.DiscountAmount;
            TotalAmount += item.TotalPrice;
            CartForPayAmount = TotalAmount - DiscountAmount;
            CartItems.Add(item);
        }
    }
}