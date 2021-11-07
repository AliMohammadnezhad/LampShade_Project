using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

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
                .Include(x=>x.Role)
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
                Role = x.Role.Name,
                Username = x.Username,
                CreationDate = x.CreationDate.ToFarsi()
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<AccountViewModel> Search()
        {
            return _context.Accounts
                .Include(x=>x.Role)
                .Select(x => new AccountViewModel
                {
                    FullName = x.FullName,
                    Id = x.Id,
                    Mobile = x.Mobile,
                    ProfilePhoto = x.ProfilePhoto,
                    Role = x.Role.Name,
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

        public LoginViewModel GetBy(string username)
        {
            return _context.Accounts.Select(x => new LoginViewModel
            {
                Mobile = x.Mobile,
                Password = x.Password,
                RoleId = x.RoleId,
                Username = x.Username,
                Id = x.Id,
                FullName = x.FullName,
                PicturePath = x.ProfilePhoto
            }).FirstOrDefault(x => x.Username == username);
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _context.Accounts.Select(x => new AccountViewModel
            {
                FullName = x.FullName,
                Id = x.Id
            }).ToList();
        }
    }
}
