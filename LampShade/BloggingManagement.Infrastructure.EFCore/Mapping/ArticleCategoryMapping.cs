using BloggingManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1200);
            builder.Property(x => x.Picture).HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(250);
            builder.Property(x => x.KeyWords).HasMaxLength(100);
            builder.Property(x => x.MetaDescription).HasMaxLength(150);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasMany(x => x.Articles).WithOne(x => x.ArticleCategory).HasForeignKey(x => x.CategoryId);
        }
    }
}
