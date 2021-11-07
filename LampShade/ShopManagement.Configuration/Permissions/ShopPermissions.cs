namespace ShopManagement.Configuration.Permissions
{
    public static class ShopPermissions
    {
        //Product
        public const int ListProducts = 10;
        public const int SearchProducts = 11;
        public const int CreateProduct = 12;
        public const int EditProduct = 13;


        //ProductCategory
        public const int ListProductCategories = 20;
        public const int SearchProductCategories = 21;
        public const int CreateProductCategory = 22;
        public const int EditProductCategory = 23;
        public const int RemoveProductCategory = 24;
        public const int RestoreProductCategory = 25;

        //ProductPicture
        public const int CreateProductPicture = 30;
        public const int EditProductPicture = 31;
        public const int RemoveProductPicture = 32;
        public const int RestoreProductPicture = 33;
        public const int SearchProductPicture = 34;



        //Slide
        public const int CreateSlide = 40;
        public const int EditSlide = 41;
        public const int RemoveSlide = 42;
        public const int RestoreSlide = 43;
        public const int ListSlide = 44;

        //Orders
        public const int ShowOrderItems = 120;
        public const int ConfirmOrder = 121;
        public const int CancelOrder = 122;
        public const int SearchOrders = 123;
    }
}