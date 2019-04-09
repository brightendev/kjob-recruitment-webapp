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


        public async Task<ActionResult> Index([FromQuery] string category)
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
            //  else return RedirectToAction("Public", "JobBoard");

            List<Data.Job.JobListData> jobList = await Data.Job.GetJobList();
            jobList.Reverse();
            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();
            
            if(category == null) category = "all";
            ViewData["JobList"] = jobList;
            ViewData["CategoryList"] = categoryList;
            ViewData["SelectedCategory"] = category;

            return View("public_jobboard");
        }

        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult> Candidate([FromQuery] string category) {

            List<Data.Job.JobListData> jobList = await Data.Job.GetJobList();
            jobList.Reverse();
            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();

            if (category == null) category = "all";
            ViewData["JobList"] = jobList;
            ViewData["CategoryList"] = categoryList;
            ViewData["SelectedCategory"] = category;

            return View("candidate_jobboard");

        }

        [Authorize(Roles = "Staff")]
        public async Task<ActionResult> Staff([FromQuery] string category) {

            List<Data.Job.JobListData> jobList = await Data.Job.GetJobList();
            jobList.Reverse();
            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();

            if (category == null) category = "all";
            ViewData["JobList"] = jobList;
            ViewData["CategoryList"] = categoryList;
            ViewData["SelectedCategory"] = category;

            return View("staff_jobboard");
        }

     //   [Authorize(Roles = "Staff")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Admin([FromQuery] string category) {

            List<Data.Job.JobListData> jobList = await Data.Job.GetJobList();
            jobList.Reverse();
            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();
            
            if(category == null) category = "all";
            ViewData["JobList"] = jobList;
            ViewData["CategoryList"] = categoryList;
            ViewData["SelectedCategory"] = category;

            return View("staff_jobboard");
        }

        [Authorize(Roles = "Staff, Admin")]
        public async Task<ActionResult> AddJob() {

            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();
            ViewData["CategoryList"] = categoryList;

            return View();
        }

        [HttpPost]
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

        [AllowAnonymous]
        // ============ Job Detail ==============
        public async Task<ActionResult> JobDetailPublic(string job) {

            Data.Job.JobAllData selectedJob = await Data.Job.GetJobDetail(job);
            Console.WriteLine("job id = "+ selectedJob.id);
            Console.WriteLine("job title = " + selectedJob.title);
            Console.WriteLine("job category = " + selectedJob.category);

            ViewData["SelectedJob"] = selectedJob;

            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();
            ViewData["CategoryList"] = categoryList;


            // =================== job detail ========================================
            Data.Job.JobDetailData detail1 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_1);
            Data.Job.JobDetailData detail2 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_2);
            Data.Job.JobDetailData detail3 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_3);
            Data.Job.JobDetailData detail4 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_4);
            Data.Job.JobDetailData detail5 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_5);


   /*         List<string> detail1LineList = GetNotEmptyLineList(detail1);
            List<string> detail2LineList = GetNotEmptyLineList(detail2);
            List<string> detail3LineList = GetNotEmptyLineList(detail3);
            List<string> detail4LineList = GetNotEmptyLineList(detail4);
            List<string> detail5LineList = GetNotEmptyLineList(detail5);*/

       /*     List<string> detail2LineList = new List<string>();
            if (!detail2.l1.Equals("")) detail2LineList.Add(detail2.l1);
            if (!detail2.l2.Equals("")) detail2LineList.Add(detail2.l2);
            if (!detail2.l3.Equals("")) detail2LineList.Add(detail2.l3);
            if (!detail2.l4.Equals("")) detail2LineList.Add(detail2.l4);
            if (!detail2.l5.Equals("")) detail2LineList.Add(detail2.l5);
            if (!detail2.l6.Equals("")) detail2LineList.Add(detail2.l6);
            List<string> detail3LineList = new List<string>();
            if (!detail3.l1.Equals("")) detail3LineList.Add(detail3.l1);
            if (!detail3.l2.Equals("")) detail3LineList.Add(detail3.l2);
            if (!detail3.l3.Equals("")) detail3LineList.Add(detail3.l3);
            if (!detail3.l4.Equals("")) detail3LineList.Add(detail3.l4);
            if (!detail3.l5.Equals("")) detail3LineList.Add(detail3.l5);
            if (!detail3.l6.Equals("")) detail3LineList.Add(detail3.l6);
            List<string> detail4LineList = new List<string>();
            if (!detail4.l1.Equals("")) detail4LineList.Add(detail4.l1);
            if (!detail4.l2.Equals("")) detail4LineList.Add(detail4.l2);
            if (!detail4.l3.Equals("")) detail4LineList.Add(detail4.l3);
            if (!detail4.l4.Equals("")) detail4LineList.Add(detail4.l4);
            if (!detail4.l5.Equals("")) detail4LineList.Add(detail4.l5);
            if (!detail4.l6.Equals("")) detail4LineList.Add(detail4.l6);
            List<string> detail5LineList = new List<string>();
            if (!detail5.l1.Equals("")) detail5LineList.Add(detail5.l1);
            if (!detail5.l2.Equals("")) detail5LineList.Add(detail5.l2);
            if (!detail5.l3.Equals("")) detail5LineList.Add(detail5.l3);
            if (!detail5.l4.Equals("")) detail5LineList.Add(detail5.l4);
            if (!detail5.l5.Equals("")) detail5LineList.Add(detail5.l5);
            if (!detail5.l6.Equals("")) detail5LineList.Add(detail5.l6); */


        /*    List<List<string>> jobDetailList = new List<List<string>>();
            if (detail1LineList.Count != 0) jobDetailList.Add(detail1LineList);
            if (detail2LineList.Count != 0) jobDetailList.Add(detail2LineList);
            if (detail3LineList.Count != 0) jobDetailList.Add(detail3LineList);
            if (detail4LineList.Count != 0) jobDetailList.Add(detail4LineList);
            if (detail5LineList.Count != 0) jobDetailList.Add(detail5LineList);
            Console.WriteLine("jobDetailList count = " + jobDetailList.Count);*/
            //      Console.WriteLine(jobDetailList.);


            Detail jobDetail1 = new Detail()
            {
                title = detail1.title,
                LineList = GetNotEmptyLineList(detail1)
            };
            Detail jobDetail2 = new Detail()
            {
                title = detail2.title,
                LineList = GetNotEmptyLineList(detail2)
            };
            Detail jobDetail3 = new Detail()
            {
                title = detail3.title,
                LineList = GetNotEmptyLineList(detail3)
            };
            Detail jobDetail4 = new Detail()
            {
                title = detail4.title,
                LineList = GetNotEmptyLineList(detail4)
            };
            Detail jobDetail5 = new Detail()
            {
                title = detail5.title,
                LineList = GetNotEmptyLineList(detail5)
            };

            Console.WriteLine("detail 5 line list count = "+jobDetail5.LineList.Count);

            JobDetail jobDetailData = new JobDetail() {
                detailList = new List<Detail>()
            };
            if (jobDetail1.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail1);
            if (jobDetail2.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail2);
            if (jobDetail3.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail3);
            if (jobDetail4.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail4);
            if (jobDetail5.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail5);

            ViewData["JobDetailData"] = jobDetailData;

            return View();
        }


        private List<string> GetNotEmptyLineList(Data.Job.JobDetailData detailData) {

            List<string> detailLineList = new List<string>();
            if (!detailData.l1.Equals("")) detailLineList.Add(detailData.l1);
            if (!detailData.l2.Equals("")) detailLineList.Add(detailData.l2);
            if (!detailData.l3.Equals("")) detailLineList.Add(detailData.l3);
            if (!detailData.l4.Equals("")) detailLineList.Add(detailData.l4);
            if (!detailData.l5.Equals("")) detailLineList.Add(detailData.l5);
            if (!detailData.l6.Equals("")) detailLineList.Add(detailData.l6);

            return detailLineList;
        }

        public class JobDetail
        {
            public string id { get; set; }
            public string title { get; set; }
            public string min_salary { get; set; }
            public string max_salary { get; set; }
            public string category { get; set; }
            public List<Detail> detailList { get; set; }
        }

     /*   public class Line
        {
            public string text { get; set; }   
        }*/

        public class Detail
        {
            public string title { get; set; }
            public List<string> LineList { get; set; }
        }
    }
}