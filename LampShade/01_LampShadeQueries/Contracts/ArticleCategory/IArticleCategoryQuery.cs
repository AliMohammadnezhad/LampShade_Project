using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        ArticleCategoryQueryModel GetCategoryBy(string slug);
        List<ArticleCategoryQueryModel> GetCategories();
    }
}
