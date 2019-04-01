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


            // for session ==========
            services.AddDistributedMemoryCache(); // Adds a default in-memory implementation of IDistributedCache
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {

            app.Use(async delegate (HttpContext context, Func<Task> next) {
                Console.WriteLine(context.Request.Method + " " + context.Request.Path);

                await next();
            });

            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();

            // use file in wwwroot
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

                // for user controller
                routes.MapRoute("user_account_route", "account", new { controller = "User", action = "Account" });
                routes.MapRoute("user_profile_route", "profile", new { controller = "User", action = "Profile" });

                // admin
                routes.MapRoute("dashboard_accounts1", "dashboard", new { controller = "Dashboard", action = "Accounts" });
                routes.MapRoute("dashboard_accounts2", "dashboard/accounts", new { controller = "Dashboard", action = "Accounts" });


                routes.MapRoute("response_email_confirmation", "{encryptedConfirmationData}callapicreateaccount",
                    new {controller = "Register", action = "ResponseToConfirmationEmail" });

                // ========= AJAX ====
                routes.MapRoute("ajax_set_notif_all", "ajax/set_notification_all/{value}", new { controller = "AjaxHandler", action = "SetNotificationAll" });
                routes.MapRoute("ajax_set_notif_email", "ajax/set_notification_email/{value}", new { controller = "AjaxHandler", action = "SetNotificationEmail" });
                routes.MapRoute("ajax_set_notif_news", "ajax/set_notification_news/{value}", new { controller = "AjaxHandler", action = "SetNotificationNews" });
                routes.MapRoute("ajax_set_notif_interestedjob", "ajax/set_notification_interested/{value}", new { controller = "AjaxHandler", action = "SetNotificationInterested" });

                // test
                routes.MapRoute("ajax_test_blood", "ajax/getallblood", new { controller = "AjaxHandler", action = "GetAllBlood" });
                routes.MapRoute("ajax_test_role", "ajax/getrole", new { controller = "AjaxHandler", action = "GetRole" });

                // ============
                routes.MapRoute("home admin", "admin", new {controller = "Home", action = "admin"});
                routes.MapRoute("home candidate", "candidate", new { controller = "Home", action = "candidate" });
            });
        }

    }
}
