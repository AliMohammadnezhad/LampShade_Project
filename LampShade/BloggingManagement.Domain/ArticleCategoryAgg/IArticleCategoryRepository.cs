using System.Collections.Generic;
using _0_FrameWork.Domain;
using BloggingManagement.Application.Contract.ArticleCategory;

namespace BloggingManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository:IRepository<long,ArticleCategory>
    {
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search();
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
        List<ArticleCategoryViewModel> GetArticleCategories();
        string GetCategorySlugBy(long id);

    }
}
