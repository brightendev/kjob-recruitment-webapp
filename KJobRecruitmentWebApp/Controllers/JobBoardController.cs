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

            if (User.IsInRole("Candidate"))
            {
                return RedirectToAction("JobDetailCandidate", "JobBoard");
            }

            Data.Job.JobAllData selectedJob = await Data.Job.GetJobDetail(job);
            ViewData["SelectedJob"] = selectedJob;

            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();
            ViewData["CategoryList"] = categoryList;


            // =================== job detail ========================================
            Data.Job.JobDetailData detail1 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_1);
            Data.Job.JobDetailData detail2 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_2);
            Data.Job.JobDetailData detail3 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_3);
            Data.Job.JobDetailData detail4 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_4);
            Data.Job.JobDetailData detail5 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_5);


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


        // ================== Job Detail for candidate =========
        public async Task<ActionResult> JobDetailCandidate(string job)
        {

            Data.Job.JobAllData selectedJob = await Data.Job.GetJobDetail(job);
            ViewData["SelectedJob"] = selectedJob;

            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();
            ViewData["CategoryList"] = categoryList;


            // =================== job detail ========================================
            Data.Job.JobDetailData detail1 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_1);
            Data.Job.JobDetailData detail2 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_2);
            Data.Job.JobDetailData detail3 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_3);
            Data.Job.JobDetailData detail4 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_4);
            Data.Job.JobDetailData detail5 = JsonConvert.DeserializeObject<Data.Job.JobDetailData>(selectedJob.detail_5);


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

            Console.WriteLine("detail 5 line list count = " + jobDetail5.LineList.Count);

            JobDetail jobDetailData = new JobDetail()
            {
                detailList = new List<Detail>()
            };
            if (jobDetail1.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail1);
            if (jobDetail2.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail2);
            if (jobDetail3.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail3);
            if (jobDetail4.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail4);
            if (jobDetail5.LineList.Count != 0) jobDetailData.detailList.Add(jobDetail5);

            ViewData["JobDetailData"] = jobDetailData;

            return View("job_detail_candidate");
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

        public class Detail
        {
            public string title { get; set; }
            public List<string> LineList { get; set; }
        }

        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult> ApplyAJob(string job) {

            ViewData["ApplyingJob"] = job;
            return View("job_apply");
        }
    }
}