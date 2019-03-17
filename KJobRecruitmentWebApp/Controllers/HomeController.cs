using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
                Console.WriteLine("in role Admin");
                return RedirectToAction("Admin", "Home");
            }
            Console.WriteLine("User is not in any role");
            return View();
        }

        [Authorize(Roles = "Candidate")]
        public IActionResult Candidate() {

            ViewData["uid"] = ((ClaimsIdentity)User.Identity).FindFirst("uid");

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