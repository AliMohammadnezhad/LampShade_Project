using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.Comment
{
    public interface ICommentQuery
    {
        List<CommentQueryModel> GetProductComment(long id);
    }
}
