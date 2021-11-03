using System.Collections.Generic;
using System.Linq;
using _01_LampShadeQueries.Contracts.Article;
using _01_LampShadeQueries.Contracts.ArticleCategory;
using BloggingManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace _01_LampShadeQueries.Queries
{
    public class ArticleCategoryQuery:IArticleCategoryQuery
    {
        private readonly BloggingContext _bloggingContext;

        public ArticleCategoryQuery(BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        public ArticleCategoryQueryModel GetCategoryBy(string slug)
        {
            return _bloggingContext.ArticleCategories.Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Slug == slug);
        }

        public List<ArticleCategoryQueryModel> GetCategories()
        {
            return _bloggingContext.ArticleCategories.Include(x => x.Articles).Select(x => new ArticleCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                ArticleCount = x.Articles.Count,
                Slug = x.Slug,
                KeyWords = x.KeyWords,
                Articles = x.Articles.Select(article=>new ArticleQueryModel
                {
                    Title = article.Title,
                    Slug = article.Slug
                }).ToList()
            }).ToList();
        }
    }
}
