using System;
using _0_FrameWork.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public int RoleId { get; private set; }
        public string ProfilePhoto { get; private set; }

        public Account(string fullName, string username, string password, string mobile, int roleId, string profilePhoto)
        {
            FullName = fullName;
            Username = username;
            Password = password;
            Mobile = mobile;
            RoleId = roleId;
            ProfilePhoto = profilePhoto;
            CreationDate = DateTime.Now;
        }

        public void Edit(string fullName, string mobile, int roleId, string profilePhoto)
        {

            FullName = fullName;
            Mobile = mobile;
            RoleId = roleId;
            if(!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
        }

        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}
