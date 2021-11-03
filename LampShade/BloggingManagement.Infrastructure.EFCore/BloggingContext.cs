using BloggingManagement.Domain.ArticleAgg;
using BloggingManagement.Domain.ArticleCategoryAgg;
using BloggingManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace BloggingManagement.Infrastructure.EFCore
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> context) : base(context)
        {

        }

        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
