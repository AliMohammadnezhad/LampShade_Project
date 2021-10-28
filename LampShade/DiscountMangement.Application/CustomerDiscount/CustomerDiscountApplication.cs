using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using DiscountManagement.Application.Contract.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;

namespace DiscountManagement.Application.CustomerDiscount
{
    public class CustomerDiscountApplication:ICustomerDiscountApplication
    {
        private readonly ICustomerDiscountRepository _discountRepository;

        public CustomerDiscountApplication(ICustomerDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }
        public OperationResult Define(DefineCustomerDiscount command)
        {
            var operationResult = new OperationResult();
            if (_discountRepository.Exists(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var customerDiscount = new Domain.CustomerDiscountAgg.CustomerDiscount(command.ProductId, command.DiscountRate,
                command.StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.Reason);
            _discountRepository.Create(customerDiscount);
            _discountRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditCustomerDiscount command)
        {
            var operationResult = new OperationResult();
            var discount = _discountRepository.Get(command.Id);
            if (discount == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_discountRepository.Exists(x =>
                x.ProductId == command.ProductId && x.DiscountRate == command.DiscountRate && x.Id != discount.Id))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            discount.Edit(command.ProductId, command.DiscountRate,
                command.StartDate.ToGeorgianDateTime(), command.EndDate.ToGeorgianDateTime(), command.Reason);
            _discountRepository.SaveChange();
            return operationResult.Succeed();
        }

        public EditCustomerDiscount GetDetails(long id)
        {
            var editCustomerDiscount = _discountRepository.GetDetails(id);
            return editCustomerDiscount;
        }

        public List<CustomerDiscountViewModel> Search(CustomerDiscountSearchModel searchModel)
        {
            if (searchModel.StartDate != null || searchModel.EndDate != null || searchModel.ProductId > 0)
                 return _discountRepository.Search(searchModel);

            return _discountRepository.Search();
        }
    }
}
