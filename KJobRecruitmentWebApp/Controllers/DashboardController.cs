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
        public async Task<ActionResult> Index()
        {
            string userEmail = HttpContext.Session.GetString(System.SessionVariable.email);
            Console.WriteLine($"user email = {userEmail}");

            List<Data.Admin.Account> accountList = (await Data.Admin.GetAllAccounts(userEmail));

            foreach(Admin.Account account in accountList) {
                
                Console.WriteLine(account.email);
            }

            ViewData["AccountList"] = accountList;

            return View();
        }
    }
}