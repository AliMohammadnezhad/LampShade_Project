using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using _0_FrameWork.Infrastructure;
using BloggingManagement.Application.Contract.ArticleCategory;
using BloggingManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
    public class IndexModel : PageModel
    {
        public ArticleCategorySearchModel SearchModel;
        public List<ArticleCategoryViewModel> ArticleCategories;

        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        [NeedsPermission(BloggingPermissions.SearchArticleCategory)]
        public void OnGet(ArticleCategorySearchModel searchModel)
        {
            ArticleCategories = _articleCategoryApplication.Search(searchModel);
        }

        [NeedsPermission(BloggingPermissions.CreateArticleCategory)]
        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateArticleCategory());
        }

        [NeedsPermission(BloggingPermissions.CreateArticleCategory)]
        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }

        [NeedsPermission(BloggingPermissions.EditArticleCategory)]
        public IActionResult OnGetEdit(long id)
        {
            var productCategory = _articleCategoryApplication.GetDetails(id);
            return Partial("Edit", productCategory);
        }

        [NeedsPermission(BloggingPermissions.EditArticleCategory)]
        public JsonResult OnPostEdit(EditArticleCategory command)
        {
            var result = _articleCategoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
