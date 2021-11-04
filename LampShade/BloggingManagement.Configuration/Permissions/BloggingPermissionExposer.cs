using System.Collections.Generic;
using _0_FrameWork.Infrastructure;

namespace BloggingManagement.Configuration.Permissions
{
    public class BloggingPermissionExposer:IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>()
            {
                {
                    "گروه خبری", new List<PermissionDto>()
                    {
                        new PermissionDto(BloggingPermissions.CreateArticleCategory, "ايجاد گروه خبري"),
                        new PermissionDto(BloggingPermissions.EditArticleCategory, "ويرايش گروه خبري"),
                        new PermissionDto(BloggingPermissions.SearchArticleCategory, "جست و جو گروه خبري"),
                    }
                },
                {
                    "اخبار", new List<PermissionDto>()
                    {
                        new PermissionDto(BloggingPermissions.CreateArticle, "ايجاد گروه خبري"),
                        new PermissionDto(BloggingPermissions.EditArticle, "ويرايش  خبر"),
                        new PermissionDto(BloggingPermissions.SearchArticle, "جست و جو  خبر"),
                    }
                },
            };
        }
    }
}
