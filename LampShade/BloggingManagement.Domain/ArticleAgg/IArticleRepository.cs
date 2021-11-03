using System.Collections.Generic;
using _0_FrameWork.Domain;
using BloggingManagement.Application.Contract.Article;

namespace BloggingManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        List<ArticleViewModel> Search();
        List<ArticleViewModel> Search(ArticleSearchModel command);
        EditArticle GetDetails(long id);
        List<ArticleViewModel> GetArticles();
    }
}
