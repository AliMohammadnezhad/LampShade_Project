using System.Collections.Generic;
using _0_Framework.Application;
using _01_LampShadeQueries.Contracts.Article;
using _01_LampShadeQueries.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticlesModel : PageModel
    {
        public List<ArticleQueryModel> Articles;
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> Categories;
        public string Category { get; set; }
        public string CategorySlug { get; set; }

        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategory;
        
        public ArticlesModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategory)
        {
            _articleQuery = articleQuery;
            _articleCategory = articleCategory;
        }

        public void OnGet(string? id)
        {
            LatestArticles = _articleQuery.GetLatestArticles();
            CategorySlug = id;
            Categories = _articleCategory.GetCategories();
            Category = _articleCategory.GetCategoryBy(CategorySlug)?.Name;
            Articles = _articleQuery.GetArticles(CategorySlug);
            Response.Cookies.Append("CookieName", "value");

        }
    }
}
