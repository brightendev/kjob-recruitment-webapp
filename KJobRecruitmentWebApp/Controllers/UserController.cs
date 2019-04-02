using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/account");
        }

        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult> Account() {
           
      /*      var data = System.User.User.GetUserDetail("email");
            ViewData["email"] = data.account.email;
            ViewData["create_date"] = data.account.create_date;
            ViewData["last_login"] = data.account.last_login;

            ViewData["personal_id"] = data.profile.personal_id;*/

            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            Data.User.AccountData account = await Data.User.GetAccount(uid);
            ViewData["email"] = account.email;
            ViewData["last_login"] = account.last_login;
            ViewData["created_date"] = account.created_date;
            ViewData["notif_all"] = account.notif_all;
            ViewData["notif_email"] = account.notif_email;
            ViewData["notif_news"] = account.notif_news;
            ViewData["notif_interested"] = account.notif_interested;

            Console.WriteLine($"email = {ViewData["email"]}, createDate = {ViewData["createDate"]}");

            return View();
        }

        public ActionResult Profile() {

            return View();
        }
    }
}