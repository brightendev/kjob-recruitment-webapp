using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    public class JobBoardController : Controller
    {

        public class JobSubmitData
        {
            public string title { get; set; }
        /*    public string min_salary { get; set; }
            public string max_salary { get; set; }
            public string category { get; set; }
            public string detail_1 { get; set; }
            public string detail_2 { get; set; }
            public string detail_3 { get; set; }
            public string deatIL_4 { get; set; }
            public string deatail_5 { get; set; }*/
        }

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

     //   [Authorize(Roles = "Staff")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Admin() {

            List<Data.Job.JobListData> jobList = await Data.Job.GetJobList();
            List<Data.Job.Category> ca0CategoryList = Data.Job.GetCategoryList();

            ViewData["JobList"] = jobList;
            ViewData["CategoryList"] = ca0CategoryList;

            return View();
        }

        public ActionResult AddJob() {

            return View();
        }

        [HttpPost]
        public string AddJobPost([FromBody]JobSubmitData job) {

        //    string request = await Request.Body.;

            Console.Write("Post Job receive data = "+ job.title);

            return "success";
        }
    }
}