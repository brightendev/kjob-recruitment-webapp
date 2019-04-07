using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KJobRecruitmentWebApp.Controllers
{
    public class JobBoardController : Controller
    {

        public class JobSubmitData
        {
            public string title { get; set; }
            public string min_salary { get; set; }
            public string max_salary { get; set; }
            public string category { get; set; }
            public string detail_1 { get; set; }
            public string detail_2 { get; set; }
            public string detail_3 { get; set; }
            public string detail_4 { get; set; }
            public string detail_5 { get; set; }
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
            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();
            jobList.Reverse();

            ViewData["JobList"] = jobList;
            ViewData["CategoryList"] = categoryList;

            return View();
        }

        public ActionResult AddJob() {

          //  string test = GetJobCategoryList();
          //  Console.WriteLine(test);

            return View();
        }

     //   [HttpPost]
        public async Task<string> AddJobPost([FromBody]JobSubmitData job) {

        //    string request = await Request.Body.;

            Console.WriteLine("Post Job title = "+ job.title);
            Console.WriteLine("Post Job nix salary = " + job.min_salary);
            Console.WriteLine("Post Job max salary = " + job.max_salary);
            Console.WriteLine("Post Job max category = " + job.category);
            Console.WriteLine("Post Job detail1 = " + job.detail_1);
            Console.WriteLine("Post Job detail2 = " + job.detail_2);
            Console.WriteLine("Post Job detail3 = " + job.detail_3);
            Console.WriteLine("Post Job detail4 = " + job.detail_4);
            Console.WriteLine("Post Job detail5 = " + job.detail_5);

            return await System.Services.ApiInterfacer.AddJob(job.title, job.min_salary, job.max_salary, job.category,
                job.detail_1, job.detail_2, job.detail_3, job.detail_4, job.detail_5);

            return "success";
        }

        // ====== 
     /*   public string GetJobCategoryList() {

            List<Data.Job.Category> categoryList = Data.Job.GetCategoryList();

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.WriteStartArray();
                
                foreach (Data.Job.Category category in categoryList) {
              //      jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("id");
                    jsonWriter.WriteValue(category.id);
                    jsonWriter.WritePropertyName("name");
                    jsonWriter.WriteValue(category.name);
             //       jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
            }

            return sw.ToString();
        }*/
    }
}