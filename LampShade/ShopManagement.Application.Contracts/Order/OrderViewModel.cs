using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Order
{
    public class OrderViewModel
    {
        public long OrderId { get; set; }
        public long AccountId { get; set; }
        public double TotalAmount { get; set; }
        public double DiscountAmount { get; set; }
        public double PayAmount { get; set; }
        public long PaymentMethodId { get; set; }
        public bool IsPaid { get; set; }
        public bool IsCanceled { get; set; }
        public string IssueTrackingNo { get; set; }
        public long RefId { get; set; }
        public string AccountName { get; set; }
        public string DateTime { get; set; }
        public string PaymentMethod { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }

    }
}
