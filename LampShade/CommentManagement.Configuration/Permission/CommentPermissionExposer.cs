using System.Collections.Generic;
using _0_FrameWork.Infrastructure;

namespace CommentManagement.Configuration.Permission
{
    public class CommentPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "مدیریت کامنت", new List<PermissionDto>()
                    {
                        new PermissionDto(CommentPermissions.ConfirmComment, "تایید کامنت"),
                        new PermissionDto(CommentPermissions.UnConfirmComment, "عدم تایید کامنت"),
                        new PermissionDto(CommentPermissions.SearchComment, "جست و جو کامنت")
                    }
                }
            };
        }
    }
}
