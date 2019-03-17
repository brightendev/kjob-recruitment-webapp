using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Controllers
{
    public class LoginController : Controller
    {
        public class LoginData
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginData acc) {

            string response = await LoginModel.TryLogin(acc.email, acc.password);

            if(response.Contains("error")) return Redirect("login");

            Console.WriteLine(response);

            ClaimsIdentity identity = LoginModel.ClaimIdentity(response);

            Authorize(identity);

            return Redirect("/");
        }

        private async void Authorize(ClaimsIdentity identity) {

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddSeconds(30)
                }
            );

            User.AddIdentity(identity);
        }

        public ActionResult FirstLogin() {

            return View();
        }
    }
}