using System;
using System.Collections.Generic;
using _0_FrameWork.Domain;

namespace CommentManagement.Domain.CommentAgg
{
    public class Comment : EntityBase
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string CommentText { get; private set; }
        public bool IsConfirmed { get; private set; }
        public long OwnerRecordId { get; private set; }
        public int Type { get; private set; }
        public long ParentId { get; private set; }
        public Comment Parent { get; private set; }
        public List<Comment> Children { get; private set; }
        public Comment(string name, string email, string commentText,long ownerRecordId,int type,long parentId)
        {
            Name = name;
            Email = email;
            CommentText = commentText;
            IsConfirmed = false;
            OwnerRecordId = ownerRecordId;
            Type = type;
            ParentId = parentId;
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
