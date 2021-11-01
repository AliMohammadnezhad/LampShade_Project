﻿namespace CommentManagement.Application.Contract.Comment
{
    public class CommentViewModel
    {
        public long CommentId { get; set; }
        public long ProductId { get; set; }
        public string CreateDate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CommentText { get; set; }
        public bool IsConfirmed { get; set; }
        public string Product { get; set; }
    }
}