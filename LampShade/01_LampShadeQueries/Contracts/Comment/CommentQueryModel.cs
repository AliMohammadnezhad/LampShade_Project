using System.Collections.Generic;

namespace _01_LampShadeQueries.Contracts.Comment
{
    public class CommentQueryModel
    {
        public string CreationDate { get; set; }
        public long CommentId { get; set; }
        public string Name { get; set; }
        public string MessageText { get; set; }
        public long OwnerRecordId { get; set; }
        public long ParentId { get; set; }
        public List<CommentQueryModel>? Children { get; set; }
    }
}
