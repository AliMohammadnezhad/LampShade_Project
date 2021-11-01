using System;
using _0_FrameWork.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment:EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CommentText { get; private set; }
        public bool IsConfirmed { get; private set; }
        public long ProductId { get; private set; }

        public Comment(string name, string email, string commentText, long productId)
        {
            Name = name;
            Email = email;
            CommentText = commentText;
            IsConfirmed = false;
            ProductId = productId;
            CreationDate = DateTime.Now;
        }

        public void Confirm()
        {
            IsConfirmed = true;
        }

        public void UnConfirm()
        {
            IsConfirmed = false;
        }


    }
}
