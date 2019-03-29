using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/account");
        }

        public IActionResult Account() {
           
            var data = System.User.User.GetUserDetail("email");
            ViewData["email"] = data.account.email;
            ViewData["create_date"] = data.account.create_date;
            ViewData["last_login"] = data.account.last_login;

            ViewData["personal_id"] = data.profile.personal_id;
            return View();
        }
    }
}