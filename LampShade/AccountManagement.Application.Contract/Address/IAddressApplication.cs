using _0_FrameWork.Application;

namespace AccountManagement.Application.Contract.Address
{
    public interface IAddressApplication
    {
        OperationResult Create(CreateAddress command);
        OperationResult Edit(EditAddress command);
        EditAddress GetDetail(long accountId);
        bool UserHasAddress(long accountId);

        string GetAddressByUser(long id);
    }
}
