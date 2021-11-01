namespace _01_LampShadeQueries.Contracts.Comment
{
    public class CommentQueryModel
    {
        public long CommentId { get; set; }
        public string Name { get; set; }
        public string MessageText { get; set; }
        public long ProductId { get; set; }
    }
}
