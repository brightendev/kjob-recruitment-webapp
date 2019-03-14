using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult Index(LoginData acc)
        {

            return View();
        }
    }
}