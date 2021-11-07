using ShopManagement.Application.Contracts.Order;

namespace ShopManagement.Application
{
    public class CartService:ICartService
    {
        private Cart Cart { get; set; }


        public Cart Get()
        {
            return Cart;
        }

        public void Set(Cart cart)
        {
            Cart = cart;
        }




    }
}
