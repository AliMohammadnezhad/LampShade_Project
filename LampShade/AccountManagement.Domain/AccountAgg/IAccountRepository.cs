using System.Collections.Generic;
using _0_FrameWork.Domain;
using AccountManagement.Application.Contract.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepository<long, Account>
    {
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        List<AccountViewModel> Search();
        EditAccount GetDetails(long id);
        LoginViewModel GetBy(string username);
    }
}
