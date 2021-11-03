using System.Collections.Generic;
using BloggingManagement.Application.Contract.Article;
using CommentManagement.Application.Contract.Comment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Comments.ArticlesComment
{
    public class IndexModel : PageModel
    {
        public List<CommentViewModel> Comments;
        public CommentSearchModel SearchModel;
        public SelectList Articles;
        private readonly ICommentApplication _commentApplication;
        private readonly IArticleApplication _articleApplication;

        public IndexModel(ICommentApplication commentApplication, IArticleApplication articleApplication)
        {
            _commentApplication = commentApplication;
            _articleApplication = articleApplication;
        }
        public void OnGet(CommentSearchModel searchModel)
        {
            Articles = new SelectList(_articleApplication.GetArticles(), "Id", "Title");
            searchModel.CommentsType = CommentsType.Article;
            Comments = _commentApplication.Search(searchModel);
        }
        public JsonResult OnGetConfirm(long id)
        {
            var operationResult = _commentApplication.Confirm(id);
            return operationResult.IsSucceed ? new JsonResult(operationResult.Succeed()) : new JsonResult(operationResult);
        }

        public JsonResult OnGetUnConfirm(long id)
        {
            var operationResult = _commentApplication.UnConfirm(id);
            return operationResult.IsSucceed ? new JsonResult(operationResult.Succeed()) : new JsonResult(operationResult);
        }
    }
}
