using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Controllers
{
    public class RegisterController : Controller
    {
        public class SubmitData
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SubmitData acc)
        {

            RegisterModel.CreateAccount(acc.email, acc.password);

            return View();
        }

        public async Task<string> ResponseToConfirmationEmail(string encryptedConfirmationData) {

            return await RegisterModel.ResponseToConfirmationEmail(encryptedConfirmationData);
        }
    }
}