using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;

        public SlideApplication(ISlideRepository context)
        {
            _slideRepository = context;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operationResult = new OperationResult();
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading,
                command.Title, command.Text, command.BtnText,command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(command.Id);
            if (slide == null) return operationResult.Failed(ApplicationMessages.RecordNotFound);
            slide.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.Heading, command.Title,
                command.Text, command.BtnText,command.Link);
            _slideRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null) return operationResult.Failed(ApplicationMessages.RecordNotFound);
            slide.Restore();
            _slideRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null) return operationResult.Failed(ApplicationMessages.RecordNotFound);
            slide.Remove();
            _slideRepository.SaveChange();
            return operationResult.Succeed();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }
    }
}
