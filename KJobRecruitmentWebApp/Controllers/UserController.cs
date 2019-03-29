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

            return View();
        }
    }
}