using System.Collections.Generic;
using _0_Framework.Application;
using _0_FrameWork.Application;
using AccountManagement.Application.Contract.Role;
using AccountManagement.Domain.RoleAgg;

namespace AccountManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;

        public RoleApplication(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public OperationResult Create(CreateRole command)
        {
            var operationResult = new OperationResult();
            if (_roleRepository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);

            var role = new Role(command.Name,new List<Permission>());
            _roleRepository.Create(role);
            _roleRepository.SaveChange();
            return operationResult.Succeed();
        }

        public OperationResult Edit(EditRole command)
        {
            var operationResult = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operationResult.Failed(ApplicationMessages.RecordNotFound);
            if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.DuplicatedRecord);
            var permission = new List<Permission>();
            command.Permissions.ForEach(x=>permission.Add(new Permission(x)));
            role.Edit(command.Name, permission);
            _roleRepository.SaveChange();
            return operationResult.Succeed();
        }

        public List<RoleViewModel> List()
        {
            return _roleRepository.List();
        }

        public EditRole GetDetails(long id)
        {
            return _roleRepository.GetDetails(id);
        }
    }
}
