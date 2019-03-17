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

            Console.WriteLine(response);

            JObject respJsonObject = JsonConvert.DeserializeObject(response) as JObject;
            string uid = respJsonObject["uid"].Value<string>();
            string role = respJsonObject["role"].Value<string>();

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, acc.email),
                new Claim("uid", uid),
                new Claim(ClaimTypes.Role, role)
            };

            ClaimsIdentity identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                "uid",
                ClaimTypes.Role
            );

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

            return Redirect("/");
        }

        public ActionResult FirstLogin() {

            return View();
        }
    }
}