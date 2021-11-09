using System.Collections.Generic;
using _0_FrameWork.Domain;
using CommentManagement.Application.Contract.Comment;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> SearchProducts();
        List<CommentViewModel> SearchProducts(CommentSearchModel searchModel);
        List<CommentViewModel> SearchArticles();
        List<CommentViewModel> SearchArticles(CommentSearchModel searchModel);
        List<CommentViewModel> GetLatestComment();
        double TotalComment();
    }
}
