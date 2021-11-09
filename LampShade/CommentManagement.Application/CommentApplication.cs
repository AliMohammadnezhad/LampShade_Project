using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Domain.CommentAgg;

namespace CommentManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public OperationResult Add(AddComment command)
        {
            var operationResult = new OperationResult();
            var comment = new Comment(command.Name, command.Email, command.CommentText, command.OwnerRecordId, command.Type, command.ParentId);
            _commentRepository.Create(comment);
            _commentRepository.SaveChange();
            return operationResult.Succeed();
        }

        public List<CommentViewModel> Search(CommentSearchModel searchModel)
        {
            if (searchModel.CommentsType == CommentsType.Product)
            {
                if (searchModel.IsConfirmed || searchModel.OwnerRecordId > 0 || !string.IsNullOrWhiteSpace(searchModel.Email))
                    return _commentRepository.SearchProducts(searchModel);
                return _commentRepository.SearchProducts();
            }
            else
            {
                if (searchModel.IsConfirmed || searchModel.OwnerRecordId > 0 || !string.IsNullOrWhiteSpace(searchModel.Email))
                    return _commentRepository.SearchArticles(searchModel);
                return _commentRepository.SearchArticles();
            }
        }



        public OperationResult Confirm(long id)
        {
            var operationResult = new OperationResult();
            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            comment.Confirm();
            _commentRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult UnConfirm(long id)
        {
            var operationResult = new OperationResult();
            var comment = _commentRepository.Get(id);
            if (comment == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            comment.UnConfirm();
            _commentRepository.SaveChange();
            return operationResult.Succeed();
        }

        public List<CommentViewModel> GetLatestComment()
        {
            return _commentRepository.GetLatestComment();
        }

        public double TotalComment()
        {
            return _commentRepository.TotalComment();
        }
    }
}
