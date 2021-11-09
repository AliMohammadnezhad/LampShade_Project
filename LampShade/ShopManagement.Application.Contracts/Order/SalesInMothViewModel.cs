using System;

namespace ShopManagement.Application.Contracts.Order
{
   public class SalesInMothViewModel
    {
        public double PayAmount { get; set; }
        public DateTime CreationDateTime { get; set; }
        public double Count { get; set; }
    }
}
