using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    public class AjaxHandlerController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/");
        }

        public string SetNotificationAll() {

            return "success";
        }

        public string SetNotificationEmail()
        {
            return "success";
        }

        public string SetNotificationNews()
        {

            return "success";
        }

        public string SetNotificationInterestedJob()
        {

            return "success";
        }

        public async Task<string> GetAllBlood()
        {

            string response = await System.Services.ApiInterfacer.GettAllBloodType();

            Console.WriteLine($"=== AJax Received === blood {response}");

            return response;
        }

        public async Task<string> GetRole() {

            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);

            string response = await System.Services.ApiInterfacer.GetRole(uid);

            Console.WriteLine($"=== AJax Received === role {response}");

            return response;
        }
    }
}