using _0_FrameWork.Infrastructure;
using _01_LampShadeQueries.Contracts.Comment;
using _01_LampShadeQueries.Queries;
using CommentManagement.Application;
using CommentManagement.Application.Contract.Comment;
using CommentManagement.Configuration.Permission;
using CommentManagement.Domain.CommentAgg;
using CommentManagement.Infrastructure.EfCore;
using CommentManagement.Infrastructure.EfCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CommentManagement.Configuration
{
    public class CommentManagementBootstrapper
    {
        public static void Configure(IServiceCollection service,string connectionString)
        {
            service.AddTransient<ICommentApplication, CommentApplication>();
            service.AddTransient<ICommentRepository, CommentRepository>();

            service.AddTransient<ICommentQuery, CommentQuery>();
            service.AddTransient<IPermissionExposer, CommentPermissionExposer>();

            service.AddDbContext<CommentContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
