using System;
using System.Collections.Generic;
using _0_FrameWork.Domain;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }
        public List<Permission> Permissions { get; private set; }

        public Role()
        {
            
        }
        public Role(string name,List<Permission> permissions)
        {
            Name = name;
            CreationDate = DateTime.Now;
            Permissions = permissions;
            Accounts = new List<Account>();
        }

        public void Edit(string name,List<Permission> permissions)
        {
            Name = name;
            Permissions = permissions;
        }
    }
}
