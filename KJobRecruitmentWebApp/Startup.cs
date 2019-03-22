using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace KJobRecruitmentWebApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(delegate (CookieAuthenticationOptions options) {
                    options.LoginPath = "/login";
                    options.AccessDeniedPath = "/home";
                });

       /*     services.AddAuthorization(delegate(AuthorizationOptions options) {
                options.AddPolicy("Candidate", policy => policy.RequireRole("Candidate"));
            });*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            app.Use(async delegate (HttpContext context, Func<Task> next) {
                Console.WriteLine(context.Request.Method + " " + context.Request.Path);

                await next();
            });

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(delegate (IRouteBuilder routes) {
                routes.MapRoute("home_route", "", new {controller = "Home", action = "index"});
                routes.MapRoute("register_route", "register", new { controller = "Register", action = "index" });
                routes.MapRoute("login_route", "login", new {controller = "Login", action = "index"});
                routes.MapRoute("first_login", "firstlogin", new {controller = "Login", action = "FirstLogin"});
                
                /*ส่วนหน้าจัดการUser*/
                routes.MapRoute("account_Management", "accountManagement", new { controller = "AccountManagement", action = "index" });
                routes.MapRoute("User_Management", "UserManagement", new { controller = "AccountManagement", action = "UserManagement" });
                routes.MapRoute("User_Personal", "UserPersonal", new { controller = "AccountManagement", action = "UserPersonal" });
                routes.MapRoute("User_Work", "UserWork", new { controller = "AccountManagement", action = "UserWork" });

                routes.MapRoute("response_email_confirmation", "{encryptedConfirmationData}callapicreateaccount",
                    new {controller = "Register", action = "ResponseToConfirmationEmail" });

                // ============
                routes.MapRoute("home admin", "admin", new {controller = "Home", action = "admin"});
                routes.MapRoute("home candidate", "candidate", new { controller = "Home", action = "candidate" });
            });
        }

    }
}
