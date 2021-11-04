using _0_FrameWork.Infrastructure;
using InventoryManagement.Application;
using InventoryManagement.Application.Contract.Inventory;
using InventoryManagement.Configuration.Permissions;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore;
using InventoryManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IInventoryRepository,InventoryRepository>();
            service.AddTransient<IInventoryApplication,InventoryApplication>();

            service.AddTransient<IPermissionExposer,InventoryPermissionsExposer>();
            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
