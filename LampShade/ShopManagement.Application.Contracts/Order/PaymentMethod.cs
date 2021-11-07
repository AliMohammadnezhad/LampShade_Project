using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Application.Contracts.Order
{
    public class PaymentMethod
    {
        public long Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        private PaymentMethod(long id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public static List<PaymentMethod> GetList()
        {
            return new List<PaymentMethod>()
            {
                new PaymentMethod(1, "پرداخت اینترنتی",
                    "با این روش سفارش شما به محض پرداخت وحه از طریق درگاه بانکی ثبت و ارسال خواهد شد"),
                new PaymentMethod(2, "پرداخت نقدی",
                    "با این روش پس از تایید سفارش از طرف شما کارشناسان ما با شما تماس گرفته و پس ازپیگیری های انجام شده سفارش شما ثبت و ارسال خواهد شد "),
            };
        }

        public static PaymentMethod GetBy(long id)
        {
            return GetList().FirstOrDefault(x => x.Id == id);
        }
    }
}
