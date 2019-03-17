using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Models
{
    public class LoginModel
    {

        public static async Task<string> TryLogin(string email, string password) {

            string signinPayload = await System.Services.ApiInterfacer.Login(email, password);

            return signinPayload;
        }

        public static ClaimsIdentity ClaimIdentity(string signinPayload) {

            JObject respJsonObject = JsonConvert.DeserializeObject(signinPayload) as JObject;
            string email = respJsonObject["email"].Value<string>();
            string uid = respJsonObject["uid"].Value<string>();
            string role = respJsonObject["role"].Value<string>();

            List<Claim> claims = new List<Claim>
            {
                new Claim("Email", email),
                new Claim("Uid", uid),
                new Claim("Role", role)
            };

            ClaimsIdentity identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme,
                "Uid",
                "Role"
            );

       /*     await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddSeconds(30)
                }
            );

            User.AddIdentity(identity);*/

            return identity;
        }
    }
}
