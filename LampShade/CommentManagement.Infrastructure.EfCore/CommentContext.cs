using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CommentManagement.Infrastructure.EfCore
{
    public class CommentContext : DbContext
    {
        public CommentContext(DbContextOptions<CommentContext> options) : base(options)
        {

        }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(CommentMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
