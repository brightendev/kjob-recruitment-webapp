using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
      /*      string userEmail = HttpContext.Session.GetString(System.SessionVariable.email);
            Console.WriteLine($"user email = {userEmail}");

            List<Data.Admin.Account> accountList = (await Data.Admin.GetAllAccounts(userEmail));

            foreach(Admin.Account account in accountList) {
                
                Console.WriteLine(account.email);
            }

            ViewData["AccountList"] = accountList;

            return View();  */

            return Redirect("dashboard/accounts");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Accounts() {

            string userEmail = HttpContext.Session.GetString(System.SessionVariable.email);
            Console.WriteLine($"user email = {userEmail}");

            List<Data.Admin.Account> accountList = (await Data.Admin.GetAllAccounts(userEmail));

            foreach (Admin.Account account in accountList)
            {

                Console.WriteLine(account.email);
            }

            ViewData["AccountList"] = accountList;

            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Catagories()
        {
            string userEmail = HttpContext.Session.GetString(System.SessionVariable.email);
            Console.WriteLine($"user email = {userEmail}");

            List<Data.Job.Category> catagories = await Data.Job.GetCategoryList();

            List<Data.Job.JobListData> Job = await Data.Job.GetJobList();
            Dictionary<string, int> NumberCategory = new Dictionary<string, int>();
            foreach (Job.Category indexCatagories in catagories)
            {
                NumberCategory.Add(indexCatagories.id, 0);
            }
            foreach (Job.JobListData indexJob in Job)
            {
                if (NumberCategory.ContainsKey(indexJob.category.ToString()))
                {
                    NumberCategory[indexJob.category.ToString()] += 1;
                }
            }
            ViewData["NumberCategory"] = NumberCategory;
            ViewData["Catagories"] = catagories;
            return View();
        }

        [Authorize(Roles = "Staff")]
        public async Task<ActionResult> StaffCategories()
        {
            string userEmail = HttpContext.Session.GetString(System.SessionVariable.email);
            Console.WriteLine($"user email = {userEmail}");

            List<Data.Job.Category> catagories = await Data.Job.GetCategoryList();

            List<Data.Job.JobListData> Job = await Data.Job.GetJobList();
            Dictionary<string, int> NumberCategory = new Dictionary<string, int>();
            foreach (Job.Category indexCatagories in catagories)
            {
                NumberCategory.Add(indexCatagories.id, 0);
            }
            foreach (Job.JobListData indexJob in Job)
            {
                if (NumberCategory.ContainsKey(indexJob.category.ToString()))
                {
                    NumberCategory[indexJob.category.ToString()] += 1;
                }
            }
            ViewData["NumberCategory"] = NumberCategory;
            ViewData["Catagories"] = catagories;
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Jobs()
        {
            string userEmail = HttpContext.Session.GetString(System.SessionVariable.email);
            Console.WriteLine($"user email = {userEmail}");

            List<Data.Job.JobListData> JobList = await Data.Job.GetJobList();
            List<Job.Category> Category = await Data.Job.GetCategoryList();
            Dictionary<string,string> CategoryName= new Dictionary<string, string>();
           
            foreach (var index in Category)
             {
                CategoryName.Add(index.id,index.name);
             }

            ViewData["CategoryList"]= Category;
            ViewData["JobsList"] = JobList;
            ViewData["CategoryName"] = CategoryName;
            

            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Candidates()
        {
            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            //     Console.WriteLine($"user email = {userEmail}");

            //  List<Data.Job.JobListData> JobList = await Data.Job.GetJobList();
            //  List<Job.Category> Category = await Data.Job.GetCategoryList();
            //   Dictionary<string, string> CategoryName = new Dictionary<string, string>();

            // Data.Candidate.
            List<Data.Job.JobListData> JobList = await Data.Job.GetJobList();
            List<Data.Admin.Candidate> candidates = await Data.Admin.GetAllCandidates();
            ViewData["CandidateList"] = candidates;
            ViewData["JobList"] = JobList;

            return View();
        }
    }
}