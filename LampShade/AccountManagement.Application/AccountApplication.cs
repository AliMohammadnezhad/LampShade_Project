using System.Collections.Generic;
using System.Linq;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;

        public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateAccount command)
        {
            var operationResult = new OperationResult();
            if (_accountRepository.Exists(x => x.Username == command.Username && x.Mobile == command.Mobile))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"Users/ProfilePhoto/{command.Username}";
            var picturePath = _fileUploader.UploadFile(command.ProfilePhoto, path);
            var password = _passwordHasher.Hash(command.Password);

            var account = new Account(command.FullName, command.Username, password, command.Mobile,
                command.RoleId, picturePath);
            _accountRepository.Create(account);
            _accountRepository.SaveChange();
            return operationResult.Succeed();
        }


        public OperationResult Edit(EditAccount command)
        {
            var operationResult = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);

            if (_accountRepository.Exists(x =>
                x.Id != command.Id && x.Username != command.Username && x.Mobile == command.Mobile))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"Users/ProfilePhoto/{command.Username}";
            var picturePath = _fileUploader.UploadFile(command.ProfilePhoto, path);

            account.Edit(command.FullName, command.Mobile, command.RoleId, picturePath);
            _accountRepository.SaveChange();

            return operationResult.Succeed();
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operationResult = new OperationResult();
            var account = _accountRepository.Get(command.Id);
            if (account == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (command.Password != command.RePassword)
                return operationResult.Failed(ApplicationMessages.PasswordsNotMatch);
            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Login(LoginViewModel command)
        {
            var operationResult = new OperationResult();
            var account = _accountRepository.GetBy(command.Username);
            if (account == null)
                return operationResult.Failed(ApplicationMessages.UserNotFound);

            var passwordVerified = _passwordHasher.Check(account.Password, command.Password).Verified;

            var permission = _roleRepository.Get(account.Id).Permissions.Select(x => x.Code).ToList();
            if (!passwordVerified)
                return operationResult.Failed(ApplicationMessages.WrongUserPass);
            var authModel = new AuthViewModel(account.Id, account.RoleId, account.FullName, account.Username,
                account.Mobile,account.PicturePath,permission);
            _authHelper.Signin(authModel);

            return operationResult.Succeed();
        }

        public OperationResult Logout()
        {
            var operationResult = new OperationResult();
            _authHelper.SignOut();
            return operationResult.Succeed();
        }

        public List<AccountViewModel> Search(AccountSearchModel searchModel)
        {
            if (!string.IsNullOrWhiteSpace(searchModel.Username) || !string.IsNullOrWhiteSpace(searchModel.Mobile) ||
                !string.IsNullOrWhiteSpace(searchModel.FullName) || searchModel.RoleId > 0)
                return _accountRepository.Search(searchModel);
            return _accountRepository.Search();
        }

        public EditAccount GetDetails(long id)
        {
            return _accountRepository.GetDetails(id);
        }

        public List<AccountViewModel> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }
    }
}
