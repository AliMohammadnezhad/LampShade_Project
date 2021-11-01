using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;
        public SlideApplication(ISlideRepository context, IFileUploader fileUploader)
        {
            _slideRepository = context;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operationResult = new OperationResult();
            var path = "SlidesPicture";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);
            var slide = new Slide(picturePath, command.PictureAlt, command.PictureTitle, command.Heading,
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
            var path = "SlidesPicture";
            var picturePath = _fileUploader.UploadFile(command.Picture, path);
            slide.Edit(picturePath, command.PictureAlt, command.PictureTitle, command.Heading, command.Title,
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
