using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using DiscountManagement.Application.Contract.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application.ColleagueDiscountApplication
{
   public class ColleagueDiscountApplication:IColleagueDiscountApplication
   {
       private readonly IColleagueDiscountRepository _colleagueDiscountRepository;

       public ColleagueDiscountApplication(IColleagueDiscountRepository colleagueDiscountRepository)
       {
           _colleagueDiscountRepository = colleagueDiscountRepository;
       }
       public OperationResult Define(DefineColleagueDiscount command)
       {
           var operationResult = new OperationResult();
           if (_colleagueDiscountRepository.Exists(x =>
               x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
               return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

           var colleagueDiscount = new ColleagueDiscount(command.ProductId, command.DiscountRate);
           _colleagueDiscountRepository.Create(colleagueDiscount);
           _colleagueDiscountRepository.SaveChange();
           return operationResult.Succeed();

       }

        public OperationResult Edit(EditColleagueDiscount command)
        {
            var operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(command.Id);
            if (colleagueDiscount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            if (_colleagueDiscountRepository.Exists(x =>
                x.ProductId == command.ProductId && x.Id == command.Id && x.DiscountRate == command.DiscountRate))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            colleagueDiscount.Edit(command.Id,command.DiscountRate);
            _colleagueDiscountRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Remove(long id)
        {
            var operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Remove();
            _colleagueDiscountRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Restore(long id)
        {
            var operationResult = new OperationResult();
            var colleagueDiscount = _colleagueDiscountRepository.Get(id);
            if (colleagueDiscount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            colleagueDiscount.Restore();
            _colleagueDiscountRepository.SaveChange();
            return operationResult.Succeed();
        }

        public EditColleagueDiscount GetDetails(long id)
        {
            return _colleagueDiscountRepository.GetDetails(id);
        }
        public List<ColleagueDiscountViewModel> Search(ColleagueDiscountSearchModel command)
        {
            return command.ProductId > 0 ? _colleagueDiscountRepository.Search(command) : _colleagueDiscountRepository.Search();
        }
    }
}
