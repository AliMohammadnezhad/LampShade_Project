using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.Article;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestArticlesViewComponent:ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArticlesViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articles = _articleQuery.GetLatestArticles();
            return await Task.FromResult(View(articles));
        }
    }
}
