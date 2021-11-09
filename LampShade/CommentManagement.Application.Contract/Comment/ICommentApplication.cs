using System.Collections.Generic;
using _0_FrameWork.Application;

namespace CommentManagement.Application.Contract.Comment
{
    public interface ICommentApplication
    {
        OperationResult Add(AddComment command);
        List<CommentViewModel> Search(CommentSearchModel searchModel);
        OperationResult Confirm(long id);
        OperationResult UnConfirm(long id);
        List<CommentViewModel> GetLatestComment();
        double TotalComment();
    }
}
