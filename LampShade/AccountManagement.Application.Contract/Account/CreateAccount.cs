using Microsoft.AspNetCore.Http;

namespace AccountManagement.Application.Contract.Account
{
    public class CreateAccount
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public IFormFile ProfilePhoto { get; set; }
    }
}
