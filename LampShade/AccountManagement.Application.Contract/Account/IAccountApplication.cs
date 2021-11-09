using System.Collections.Generic;
using _0_FrameWork.Application;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        OperationResult Create(CreateAccount command);
        OperationResult Edit(EditAccount command);
        OperationResult ChangePassword(ChangePassword command);
        OperationResult Login(LoginViewModel command);
        OperationResult Logout();
        List<AccountViewModel> Search(AccountSearchModel searchModel);
        EditAccount GetDetails(long id);
        List<AccountViewModel> GetAccounts();
        PanelAccountViewModel GetAccountBy(long id);
        UserEditAccount GetDetailEditAccount(long id);
        UserEditAvatar GetAvatar(long id);
        OperationResult UserEditAccount(UserEditAccount command);
        OperationResult UserEditAvatar(UserEditAvatar command);
        OperationResult UserEditPassword(UserEditPassword command);


    }
}
