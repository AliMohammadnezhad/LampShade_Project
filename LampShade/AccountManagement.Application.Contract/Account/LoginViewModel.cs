namespace AccountManagement.Application.Contract.Account
{
    public class LoginViewModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public string Mobile { get; set; }


    }
}