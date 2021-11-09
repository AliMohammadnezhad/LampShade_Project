using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Address;
using AccountManagement.Domain.AddressAgg;

namespace AccountManagement.Application
{
    public class AddressApplication:IAddressApplication
    {
        private readonly IAddressRepository _addressRepository;

        public AddressApplication(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public OperationResult Create(CreateAddress command)
        {
            var operationResult = new OperationResult();
            if (_addressRepository.Exists(x => x.AccountId == command.AccountId))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var address = new Address(command.Country, command.State, command.City, command.FullAddress,
               command.ZipCode, command.AccountId);
            _addressRepository.Create(address);
            _addressRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditAddress command)
        {
            var operationResult = new OperationResult();
            var address = _addressRepository.Get(command.Id);
            if (address == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_addressRepository.Exists(x => x.AccountId == command.AccountId && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            address.Edit(command.Country,command.State,command.City,command.FullAddress,command.ZipCode);
            _addressRepository.SaveChange();
            return operationResult.Succeed();
        }

        public EditAddress GetDetail(long accountId)
        {
            return _addressRepository.GetDetail(accountId);
        }

        public bool UserHasAddress(long accountId)
        {
            return _addressRepository.Exists(x => x.AccountId == accountId);
        }
    }
}
