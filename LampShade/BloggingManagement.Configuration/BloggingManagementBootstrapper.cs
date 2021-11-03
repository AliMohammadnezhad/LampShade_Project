using _01_LampShadeQueries.Contracts.Article;
using _01_LampShadeQueries.Contracts.ArticleCategory;
using _01_LampShadeQueries.Queries;
using BloggingManagement.Application;
using BloggingManagement.Application.Contract.Article;
using BloggingManagement.Application.Contract.ArticleCategory;
using BloggingManagement.Domain.ArticleAgg;
using BloggingManagement.Domain.ArticleCategoryAgg;
using BloggingManagement.Infrastructure.EFCore;
using BloggingManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BloggingManagement.Configuration
{
    public class BloggingManagementBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
        {
            service.AddTransient<IArticleCategoryApplication, ArticleCategoryApplication>();
            service.AddTransient<IArticleCategoryRepository, ArticleCategoryRepository>();

            service.AddTransient<IArticleApplication, ArticleApplication>();
            service.AddTransient<IArticleRepository, ArticleRepository>();

            service.AddTransient<IArticleQuery, ArticleQuery>();
            service.AddTransient<IArticleCategoryQuery, ArticleCategoryQuery>();

            service.AddDbContext<BloggingContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
