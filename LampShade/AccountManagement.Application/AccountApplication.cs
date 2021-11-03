using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        public AccountApplication(IAccountRepository accountRepository, IFileUploader fileUploader, IPasswordHasher passwordHasher)
        {
            _accountRepository = accountRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
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
    }
}
