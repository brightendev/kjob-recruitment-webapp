using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Controllers
{
    public class AccountManagementController : Controller
    {
        public IActionResult Index()
        {
            var Account = new
            {
                email = "eee@email.com",
                role = "Candidate"
            };

            string json = JsonConvert.SerializeObject(Account);

            JObject decryptedJson = JsonConvert.DeserializeObject(json) as JObject;

            string email = decryptedJson["email"].Value<string>();
            string role = decryptedJson["role"].Value<string>();

            ViewData["email"] = email;
            ViewData["role"] = role;

            return View();
        }

        public  ActionResult UserManagement() {
            return View();
        }
        public  ActionResult UserPersonal()
        {
            return View();
        }
        public ActionResult UserWork()
        {
            return View();
        }
    }
}