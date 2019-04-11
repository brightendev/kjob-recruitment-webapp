using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {

            if (User.IsInRole("Candidate"))
            {
                StoreUserInformation();
                Console.WriteLine("in role candidate");
                return RedirectToAction("Candidate", "Home");
            }
            if (User.IsInRole("Staff"))
            {
                StoreUserInformation();
                Console.WriteLine("in role Staff");
                return RedirectToAction("Jobs", "Dashboard");
            }
            if (User.IsInRole("Admin"))
            {

                StoreUserInformation();
                Console.WriteLine("in role Admin");
                return RedirectToAction("Accounts", "Dashboard");
            }
            Console.WriteLine("User is not in any role");
            List<Data.Job.JobListData> jobList = await Data.Job.GetJobList();
            List<Data.Job.Category> catagories = await Data.Job.GetCategoryList();
            Dictionary<int, string> JobCategory = new Dictionary<int, string>();
            JObject jobDetailJObject;
            string[] detailLine1 = new string[jobList.Count];
            string[] detailTitle = new string[jobList.Count];
            for (int i = 0; i < jobList.Count; i++)
            {
                if (jobList[i].detail_1 != null)
                {
                    jobDetailJObject = JsonConvert.DeserializeObject(jobList[i].detail_1) as JObject;
                    detailTitle[i] = jobDetailJObject["title"].Value<string>();
                    detailLine1[i] = jobDetailJObject["l1"].Value<string>();
                }
                else
                {
                    detailLine1[i] = "";
                    detailTitle[i] = "";
                }

            }
            foreach (Job.Category indexCatagories in catagories)
            {
                JobCategory.Add(Convert.ToInt32(indexCatagories.id), indexCatagories.name);
            }
            ViewData["Job"] = jobList;
            ViewData["NumberJob"] = jobList.Count;
            ViewData["JobCategory"] = JobCategory;
            ViewData["detailLine1"] = detailLine1;
            ViewData["detailTitle"] = detailTitle;
            return View();
        }

        [Authorize(Roles = "Candidate")]
        public async Task<IActionResult> Candidate()
        {

            AccountController account = new AccountController();

            // JObject respJsonObject = JsonConvert.DeserializeObject(((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).ToString()) as JObject;
            // string email = respJsonObject["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"].Value<string>();

           ViewData["Email"] = HttpContext.Session.GetString(System.SessionVariable.email);
            ViewData["Uid"] = ((ClaimsIdentity)User.Identity).FindFirst("Uid").ToString().Substring(4);
            ViewData["Role"] = ((ClaimsIdentity)User.Identity).FindFirst("Role").ToString().Substring(5);

            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            string newUser = await System.Services.ApiInterfacer.IsAccountHasProfile(uid);

            Console.WriteLine($"is account have profile = {newUser}");

            if (newUser.Equals("NONE"))
            {
                return Redirect("firstlogin");
            }

            return View();
        }

        [Authorize(Roles = "Staff")]
        public IActionResult Staff()
        {

            return View();
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Admin()
        {

            return View();
        }

        private void StoreUserInformation()
        {
            HttpContext.Session.SetString(System.SessionVariable.email, ((ClaimsIdentity)User.Identity).FindFirst("Email").ToString().Substring(7));
            HttpContext.Session.SetString(System.SessionVariable.uid, ((ClaimsIdentity)User.Identity).FindFirst("Uid").ToString().Substring(5));
            HttpContext.Session.SetString(System.SessionVariable.role, ((ClaimsIdentity)User.Identity).FindFirst("Role").ToString().Substring(6));
        }
    }
}
