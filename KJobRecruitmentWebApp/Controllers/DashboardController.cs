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
    [Authorize(Roles = "Admin")]
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
    }
}