using _0_FrameWork.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BloggingManagement.Application.Contract.Article;
using BloggingManagement.Application.Contract.ArticleCategory;
using BloggingManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class EditModel : PageModel
    {
        public EditArticle Command;
        public SelectList ArticleCategories;

        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        [NeedsPermission(BloggingPermissions.EditArticle)]
        public void OnGet(long id)
        {
            Command = _articleApplication.GetDetails(id);
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(), "Id", "Name");
        }

        [NeedsPermission(BloggingPermissions.EditArticle)]
        public IActionResult OnPost(EditArticle command)
        {
            var result = _articleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
    }
}
