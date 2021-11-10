using System.Linq;
using _0_FrameWork.Infrastructure;
using AccountManagement.Application.Contract.Address;
using AccountManagement.Domain.AddressAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AddressRepository : RepositoryBase<long, Address>, IAddressRepository
    {
        private readonly AccountContext _context;

        public AddressRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public EditAddress GetDetail(long accountId)
        {
            return _context.Addresses.Select(x => new EditAddress
            {
                AccountId = x.AccountId,
                City = x.City,
                Country = x.Country,
                FullAddress = x.FullAddress,
                Id = x.Id,
                State = x.State,
                ZipCode = x.ZipCode
            }).FirstOrDefault(x => x.AccountId == accountId);
        }

        public Address GetAddressByUser(long id)
        {
            return _context.Addresses.FirstOrDefault(x => x.AccountId == id);
        }
    }
}
