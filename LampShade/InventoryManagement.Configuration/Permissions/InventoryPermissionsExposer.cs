using System.Collections.Generic;
using _0_FrameWork.Infrastructure;

namespace InventoryManagement.Configuration.Permissions
{
    public class InventoryPermissionsExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "انبارداری", new List<PermissionDto>()
                    {
                        new PermissionDto(InventoryPermissions.CreateInventory, "ایجاد انبار"),
                        new PermissionDto(InventoryPermissions.EditInventory, "ویرایش انبار"),
                        new PermissionDto(InventoryPermissions.SearchInventory, "جست و جو  انبار"),
                        new PermissionDto(InventoryPermissions.ListInventory, "لیست انبار"),
                        new PermissionDto(InventoryPermissions.Reduce, "کاهش موجودی انبار"),
                        new PermissionDto(InventoryPermissions.Increase, "افزایش موجودی انبار"),
                        new PermissionDto(InventoryPermissions.OperationLog, "مشاهده گردش انبار")
         
                    }
                }
            };
        }
    }
}
