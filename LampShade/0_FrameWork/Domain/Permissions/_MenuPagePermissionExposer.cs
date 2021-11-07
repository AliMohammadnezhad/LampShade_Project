using System;
using System.Collections.Generic;
using _0_FrameWork.Infrastructure;

namespace _0_FrameWork.Domain.Permissions
{
    public class _MenuPagePermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "داشبورد", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.DashBoard, "داشبورد")
                    }
                },
                {
                    "سيستم فروشگاهي", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.Shop, "فروشگاه"),
                        new PermissionDto(_MenuPermissions.Slider, "اسلايدر"),
                        new PermissionDto(_MenuPermissions.ProductCategories, "گروه محصولي"),
                        new PermissionDto(_MenuPermissions.ProductPictures, "تصاوير محصولات"),
                        new PermissionDto(_MenuPermissions.Products, "محصولات"),
                    }
                },
                {
                    "سيستم كاربران", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.Account, "حساب هاي كاربري"),
                        new PermissionDto(_MenuPermissions.UserManagement, "مديريت كاربران"),
                        new PermissionDto(_MenuPermissions.RolesPermission, "مديريت سطوح دسترسي"),

                    }
                },
                {
                    "سيستم تخفيفات", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.Discount, "مديريت تخفيفات"),
                        new PermissionDto(_MenuPermissions.CustomerDiscounts, " تخفيفات مشتريان"),
                        new PermissionDto(_MenuPermissions.ColleagueDiscounts, " تخفيفات همكاران"),

                    }
                },
                {
                    "سيستم وبلاگ", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.Blog, "مديريت وبلاگ"),
                        new PermissionDto(_MenuPermissions.ArticleCategory, " گروه هاي خبري"),
                        new PermissionDto(_MenuPermissions.Article, " اخبار"),

                    }
                },
                {
                    "سيستم كامنتينگ", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.Comment, "مديريت نظرات"),
                        new PermissionDto(_MenuPermissions.ShopComment, " نظرات فروشگاه"),
                        new PermissionDto(_MenuPermissions.ArticleComment, " نظرات وبلاگ"),

                    }
                }
                ,
                {
                    "سيستم انبارداري", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.Inventory, "مديريت انبار"),

                    }
                } ,
                {
                    "سيستم سفارشات", new List<PermissionDto>()
                    {
                        new PermissionDto(_MenuPermissions.Order, "مديريت سفارشات"),

                    }
                }
            };
        }
    }
}
