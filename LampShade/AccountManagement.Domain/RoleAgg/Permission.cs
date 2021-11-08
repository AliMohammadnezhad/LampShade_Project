namespace AccountManagement.Domain.RoleAgg
{
    public class Permission
    {
        public Permission(int code)
        {
            Code = code;
        }

        public Permission(int code, string name)
        {
            Code = code;
            Name = name;
        }

        public long Id { get; private set; }
        public int Code { get; }
        public string Name { get; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
    }
}