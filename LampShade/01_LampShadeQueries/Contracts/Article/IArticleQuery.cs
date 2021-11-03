using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.Article
{
    public interface IArticleQuery
    {
        List<ArticleQueryModel> GetLatestArticles();
        List<ArticleQueryModel> GetArticles(string? slug);
        ArticleQueryModel GetArticleBy(string slug);
    }
}
