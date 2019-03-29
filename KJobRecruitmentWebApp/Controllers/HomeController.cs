using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            if (User.IsInRole("Candidate"))
            {
                Console.WriteLine("in role candidate");
                return RedirectToAction("Candidate", "Home");
            }
            if (User.IsInRole("Staff"))
            {
                Console.WriteLine("in role Staff");
                return RedirectToAction("Staff", "Home");
            }
            if (User.IsInRole("Admin"))
            {
                HttpContext.Session.SetString(System.SessionVariable.email, ((ClaimsIdentity)User.Identity).FindFirst("Email").ToString().Substring(7));
                HttpContext.Session.SetString(System.SessionVariable.uid, ((ClaimsIdentity)User.Identity).FindFirst("Uid").ToString().Substring(5));
                HttpContext.Session.SetString(System.SessionVariable.role, ((ClaimsIdentity)User.Identity).FindFirst("Role").ToString().Substring(6));
                Console.WriteLine("in role Admin");
                return RedirectToAction("Index", "Dashboard");
            }
            Console.WriteLine("User is not in any role");

            return View();
        }

        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> Candidate() {

            AccountController account = new AccountController();

           // JObject respJsonObject = JsonConvert.DeserializeObject(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).ToString()) as JObject;
           // string email = respJsonObject["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"].Value<string>();

            ViewData["Email"] = ((ClaimsIdentity)User.Identity).FindFirst("Email").ToString().Substring(6);
            ViewData["Uid"] = ((ClaimsIdentity)User.Identity).FindFirst("Uid").ToString().Substring(4);
            ViewData["Role"] = ((ClaimsIdentity)User.Identity).FindFirst("Role").ToString().Substring(5);

            string newUser = await System.Services.ApiInterfacer.IsAccountHasProfile(ViewData["Uid"].ToString());

            if(newUser.Equals("NONE")) {
                return Redirect("firstlogin");
            }

            return View();
        }

        [Authorize(Roles = "Staff")]
        public IActionResult Staff() {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin() {

            return View();
        }
    }
}