using System.Collections.Generic;
using _0_FrameWork.Application;

namespace BloggingManagement.Application.Contract.Article
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
        List<ArticleViewModel> Search(ArticleSearchModel command);
        EditArticle GetDetails(long id);
        List<ArticleViewModel> GetArticles();
    }
}
