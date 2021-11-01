using System.Collections.Generic;
using _0_FrameWork.Domain;
using CommentManagement.Application.Contract.Comment;

namespace CommentManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long, Comment>
    {
        List<CommentViewModel> Search();
        List<CommentViewModel> Search(CommentSearchModel searchModel);
    }
}
