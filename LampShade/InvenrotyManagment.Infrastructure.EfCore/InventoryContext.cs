using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure.EfCore
{
    public class InventoryContext : DbContext
    {

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }

        public DbSet<Inventory> Inventory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InventoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
