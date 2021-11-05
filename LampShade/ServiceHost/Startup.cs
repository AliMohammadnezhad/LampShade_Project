using _0_Framework.Application;
using _0_FrameWork.Application;
using _0_FrameWork.Domain.Permissions;
using _0_FrameWork.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Configuration;
using BloggingManagement.Configuration;
using CommentManagement.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;

namespace ServiceHost
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("LampShadeDb");
            services.AddHttpContextAccessor();

            ShopManagementBootstrapper.Configure(services, connectionString);
            DiscountManagementBootstrapper.Configure(services,connectionString);
            InventoryManagementBootstrapper.Configure(services,connectionString);
            CommentManagementBootstrapper.Configure(services,connectionString);
            BloggingManagementBootstrapper.Configure(services,connectionString);
            AccountManagementBootstrapper.Configure(services,connectionString);

            services.AddTransient<IFileUploader, FileUploader>();
            services.AddSingleton<IPasswordHasher,PasswordHasher>();
            services.AddTransient<IAuthHelper,AuthHelper>();
            services.AddTransient<IPermissionExposer,_MenuPagePermissionExposer>();

       

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });



            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",builder=>
                    builder.RequireRole((AccountsType.Administrator).ToString(),(AccountsType.ContentManager).ToString()));

                options.AddPolicy("Shop", builder =>
                    builder.RequireRole((AccountsType.Administrator).ToString()));

                options.AddPolicy("Discount", builder =>
                    builder.RequireRole((AccountsType.Administrator).ToString()));

                options.AddPolicy("Account", builder =>
                    builder.RequireRole((AccountsType.Administrator).ToString()));

            });

            services.AddRazorPages()
                .AddMvcOptions(options=> options.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
                options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
                options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
                options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseCookiePolicy();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();

            });
        }
    }
}