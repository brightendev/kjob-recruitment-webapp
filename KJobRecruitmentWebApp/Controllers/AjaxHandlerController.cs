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

        public async Task<string> SetNotificationAll(string value) {

            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);

            Console.WriteLine($"[[ try to set notification all for uid={uid} to '{value}' ]]");

            string response = await System.Services.ApiInterfacer.SetAccountNotitification("setting_notif_all", uid, value);
            Console.WriteLine($"[[ setting notification all : {response} ]] ");

            if(response.Contains("success")) return "success";
            if(response.Contains("error")) return "error";

            return response;

        }

        public async Task<string> SetNotificationEmail(string value) {

            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            string response = await System.Services.ApiInterfacer.SetAccountNotitification("setting_notif_email", uid, value);

            if (response.Contains("success")) return "success";
            if (response.Contains("error")) return "error";

            return response;
        }

        public async Task<string> SetNotificationNews(string value)
        {
            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            string response = await System.Services.ApiInterfacer.SetAccountNotitification("setting_notif_news", uid, value);

            if (response.Contains("success")) return "success";
            if (response.Contains("error")) return "error";

            return response;
        }

        public async Task<string> SetNotificationInterested(string value)
        {
            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            string response = await System.Services.ApiInterfacer.SetAccountNotitification("setting_notif_interested", uid, value);

            if (response.Contains("success")) return "success";
            if (response.Contains("error")) return "error";

            return response;
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