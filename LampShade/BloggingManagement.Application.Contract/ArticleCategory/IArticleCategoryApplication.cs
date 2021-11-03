using System.Collections;
using System.Collections.Generic;
using _0_FrameWork.Application;

namespace BloggingManagement.Application.Contract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetDetails(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
        List<ArticleCategoryViewModel> GetArticleCategories();
    }
}
