using System.Collections.Generic;
using _0_FrameWork.Infrastructure;

namespace ShopManagement.Configuration.Permissions
{
    public class ShopPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "محصولات", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.CreateProduct,"ایجاد محصول"),
                        new PermissionDto(ShopPermissions.EditProduct,"ویرایش محصول"),
                        new PermissionDto(ShopPermissions.SearchProducts,"جست و جو محصول"),
                        new PermissionDto(ShopPermissions.ListProducts,"لیست محصول"),
                    }


                },
                {

                    "گروه محصولات", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.ListProductCategories,"لیست گروه محصولی"),
                        new PermissionDto(ShopPermissions.SearchProductCategories,"جست و جو گروه محصولی"),
                        new PermissionDto(ShopPermissions.CreateProductCategory,"ایجاد گروه محصولی"),
                        new PermissionDto(ShopPermissions.EditProductCategory,"ویرایش گروه محصولی"),
                        new PermissionDto(ShopPermissions.RemoveProductCategory,"حذف گروه محصولی"),
                        new PermissionDto(ShopPermissions.RestoreProductCategory,"بازگردانی گروه محصولی"),
                    }

                },
                {

                    "تصاویر محصولات", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.CreateProductPicture,"ایجاد تصویر محصول"),
                        new PermissionDto(ShopPermissions.EditProductPicture,"ویرایش تصویر محصول"),
                        new PermissionDto(ShopPermissions.RemoveProductPicture,"حذف تصویر محصول"),
                        new PermissionDto(ShopPermissions.RestoreProductPicture,"بازگردانی تصویر محصول"),
                        new PermissionDto(ShopPermissions.SearchProductPicture,"لیست تصویر محصول"),
                    }

                },
                {

                    "اسلاید", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.CreateSlide,"ایجاد اسلاید"),
                        new PermissionDto(ShopPermissions.EditSlide,"ویرایش اسلاید"),
                        new PermissionDto(ShopPermissions.RemoveSlide,"حذف اسلاید"),
                        new PermissionDto(ShopPermissions.RestoreSlide,"بازگردانی اسلاید"),
                        new PermissionDto(ShopPermissions.ListSlide,"لیست  اسلاید"),
                    }

                },
                {

                    "سفارشات", new List<PermissionDto>()
                    {
                        new PermissionDto(ShopPermissions.ShowOrderItems,"لیست آیتم های فاکتور"),
                        new PermissionDto(ShopPermissions.CancelOrder,"کنسل کردن فاکتور"),
                        new PermissionDto(ShopPermissions.ConfirmOrder,"تایید فاکتور"),
                        new PermissionDto(ShopPermissions.SearchOrders,"جست و جو فاکتور"),
                    }

                },
            };
        }
    }
}
