using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    public class JobBoardController : Controller
    {
        public IActionResult Index()
        {
            if (User.IsInRole("Candidate"))
            {
                return RedirectToAction("Candidate", "JobBoard");
            }
            if (User.IsInRole("Staff"))
            {
                return RedirectToAction("Staff", "JobBoard");
            }
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Admin", "JobBoard");
            }

            return View();
        }

        public ActionResult Candidate() {

            return View();
        }

        public ActionResult Staff() {
            return View();
        }

        public async Task<ActionResult> Admin() {

            await Data.Job.GetJobList();

            return View();
        }
    }
}