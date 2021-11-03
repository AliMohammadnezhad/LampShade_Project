using BloggingManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloggingManagement.Infrastructure.EFCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Picture).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(600);
            builder.Property(x => x.KeyWords).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CanonicalAddress).HasMaxLength(1000);

            builder.HasOne(x => x.ArticleCategory).WithMany(x => x.Articles).HasForeignKey(x => x.CategoryId);


        }
    }
}
