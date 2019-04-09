using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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


        public async Task<string> GetJobCategoryList()
        {

            List<Data.Job.Category> categoryList = await Data.Job.GetCategoryList();

            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            using (JsonWriter jsonWriter = new JsonTextWriter(sw))
            {
                jsonWriter.WriteStartArray();

                foreach (Data.Job.Category category in categoryList)
                {
                    jsonWriter.WriteStartObject();
                    jsonWriter.WritePropertyName("id");
                    jsonWriter.WriteValue(category.id);
                    jsonWriter.WritePropertyName("name");
                    jsonWriter.WriteValue(category.name);
                    jsonWriter.WriteEndObject();
                }
                jsonWriter.WriteEndArray();
            }

            return sw.ToString();
        }

        public async Task<string> AddNewAccount(string email, string password) {

            string response = await System.Services.ApiInterfacer.CallCreateAccount(email, password);

          //  Console.WriteLine($"=== AJax Received === blood {response}");
            
            Console.WriteLine("======== ajax handler accepted creating new account email=" + email + " passwrod=" + password);

            return response;

        }

        // change role of an account
        public async Task<string> ChangeRole(string email, string role) {

            if(!IsRequesterAdmin()) return @"{""error"":""AuthorizationFailed""}";

            Console.WriteLine("======== ajax handler accepted changing role of account email=" + email + " to role=" + role);

            string response = await System.Services.ApiInterfacer.ChangeRole(email, role);

            return response;

        }

        private bool IsRequesterAdmin() {

            string requesterRole = HttpContext.Session.GetString(System.SessionVariable.role);
            if(requesterRole == null) return false; // not login
            if(!requesterRole.Equals("Admin")) return false;

            return true;

        }
    }
}