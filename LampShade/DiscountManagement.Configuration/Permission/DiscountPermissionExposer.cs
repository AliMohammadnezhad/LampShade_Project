using System.Collections.Generic;
using _0_FrameWork.Infrastructure;

namespace DiscountManagement.Configuration.Permission
{
    public class DiscountPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "سیستم تخفبفات مشتری", new List<PermissionDto>()
                    {
                        new PermissionDto(DiscountPermission.DefineCustomerDiscount, "تغریف تخفیف مشتری"),
                        new PermissionDto(DiscountPermission.EditCustomerDiscount, "ویرایش تخفیف مشتری"),
                        new PermissionDto(DiscountPermission.SearchCustomerDiscount, "جست و جو تخفیف مشتری"),
                    }

                },
                {
                    "سیستم تخفبفات همکاری", new List<PermissionDto>()
                    {
                        new PermissionDto(DiscountPermission.DefineColleagueDiscount, "تغریف تخفیف همکاران"),
                        new PermissionDto(DiscountPermission.EditColleagueDiscount, "ویرایش همکاران"),
                        new PermissionDto(DiscountPermission.SearchColleagueDiscount, "جست و جو همکاران"),
                        new PermissionDto(DiscountPermission.RemoveColleagueDiscount, "حذف تخفیف همکاران"),
                        new PermissionDto(DiscountPermission.RestoreColleagueDiscount, "بازگردانی تخفیف همکاران"),
                    }

                }
            };
        }
    }
}
