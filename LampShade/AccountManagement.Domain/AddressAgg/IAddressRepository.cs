using _0_FrameWork.Domain;
using AccountManagement.Application.Contract.Address;

namespace AccountManagement.Domain.AddressAgg
{
    public interface IAddressRepository:IRepository<long,Address>
    {
        EditAddress GetDetail(long accountId);
    }
}
