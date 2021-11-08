using _0_FrameWork.Infrastructure;
using _01_LampShadeQueries.Contracts.Inventory;
using _01_LampShadeQueries.Queries;
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
            service.AddTransient<IProductCheckStockStatus, ProductCheckStockStatus>();
            service.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
