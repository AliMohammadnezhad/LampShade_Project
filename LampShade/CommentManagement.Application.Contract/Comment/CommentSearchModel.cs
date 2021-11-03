namespace CommentManagement.Application.Contract.Comment
{
    public class CommentSearchModel
    {
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public long OwnerRecordId { get; set; }
        public int CommentsType { get; set; }
    }
}