using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Infrastructure.EFCore.Repository
{
    public class AccountRepository:RepositoryBase<long,Account>,IAccountRepository
    {
        private readonly AccountContext _context;

        public AccountRepository(AccountContext context):base(context)
        {
            _context = context;
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            return _context.Accounts
                .Where(x=>x.FullName.Contains(searchModel.FullName) 
                          || x.Mobile.Contains(searchModel.Mobile) 
                          || x.Username.Contains(searchModel.Username) 
                          || x.RoleId == searchModel.RoleId )
                .Select(x => new AccountViewModel
            {
                FullName = x.FullName,
                Id = x.Id,
                Mobile = x.Mobile,
                ProfilePhoto = x.ProfilePhoto,
                Role = "مدیر سیستم",
                Username = x.Username,
                CreationDate = x.CreationDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<AccountViewModel> Search()
        {
            return _context.Accounts
                .Select(x => new AccountViewModel
                {
                    FullName = x.FullName,
                    Id = x.Id,
                    Mobile = x.Mobile,
                    ProfilePhoto = x.ProfilePhoto,
                    Role = "مدیر سیستم",
                    Username = x.Username,
                    CreationDate = x.CreationDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();
        }

        public EditAccount GetDetails(long id)
        {
            return _context.Accounts.Select(x => new EditAccount
            {
                FullName = x.FullName,
                Id = x.Id,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                Username = x.Username
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
