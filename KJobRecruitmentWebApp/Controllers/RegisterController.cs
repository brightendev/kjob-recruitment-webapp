using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    public class RegisterController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Account acc)
        {
            return View();
        }
    }
}