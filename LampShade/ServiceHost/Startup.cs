using _0_Framework.Application;
using _0_FrameWork.Application;
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

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddRazorPages();
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