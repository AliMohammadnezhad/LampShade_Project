﻿using System.Collections.Generic;
using _0_FrameWork.Domain;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Domain.RoleAgg
{
    public class Role : EntityBase
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }
        public Role(string name)
        {
            Name = name;
        }

        public void Edit(string name)
        {
            Name = name;
        }
    }
}
