namespace _0_FrameWork.Infrastructure
{
    public class PermissionDto
    {
        public string Name { get; set; }
        public int Code { get; set; }

        public PermissionDto(int code ,string name)
        {
            Name = name;
            Code = code;
        }
    }
}