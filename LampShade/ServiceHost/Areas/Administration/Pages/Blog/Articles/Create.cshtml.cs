
using _0_FrameWork.Infrastructure;
using BloggingManagement.Application.Contract.Article;
using BloggingManagement.Application.Contract.ArticleCategory;
using BloggingManagement.Configuration.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        public CreateArticle Command;
        public SelectList ArticleCategories;

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }
        [NeedsPermission(BloggingPermissions.CreateArticle)]
        public void OnGet()
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
            
        }
        [NeedsPermission(BloggingPermissions.CreateArticle)]
        public IActionResult OnPost(CreateArticle command)
        {
            var result = _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
