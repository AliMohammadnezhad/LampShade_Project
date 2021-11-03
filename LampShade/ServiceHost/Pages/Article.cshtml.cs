using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_LampShadeQueries.Contracts.Article;
using _01_LampShadeQueries.Contracts.ArticleCategory;
using _01_LampShadeQueries.Contracts.Comment;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article;
        public List<ArticleCategoryQueryModel> Categories { get; set; }
        public List<ArticleQueryModel> LatestArticles { get; set; }

        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategory;
        private readonly ICommentApplication _commentApplication;

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategory, ICommentApplication commentApplication)
        {
            _articleQuery = articleQuery;
            _articleCategory = articleCategory;
            _commentApplication = commentApplication;
        }

        public void OnGet(string id)
        {
            LatestArticles = _articleQuery.GetLatestArticles();
            Categories = _articleCategory.GetCategories();
            Article = _articleQuery.GetArticleBy(id);
        }

        public IActionResult OnPost(AddComment command, string articleSlug)
        {
            command.Type = CommentsType.Article;
            _commentApplication.Add(command);
            return RedirectToPage("./Article", new { Id = articleSlug });
        }
    }
}
