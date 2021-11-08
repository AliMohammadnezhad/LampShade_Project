using AccountManagement.Domain.AccountAgg;
using ShopManagement.Domain.Service;

namespace ShopManagement.Infrastructure.AccountAcl
{
    public class ShopAccountAcl : IShopAccountAcl
    {
        private readonly IAccountRepository _accountRepository;

        public ShopAccountAcl(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public (string FullName, string Mobile) GetAccountForSendSmsBy(long id)
        {
            var account = _accountRepository.Get(id);
            return (account.FullName, account.Mobile);
        }
    }
}
