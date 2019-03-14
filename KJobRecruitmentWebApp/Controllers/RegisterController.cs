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

        public string CallApiCreateAccount(string encryptedAccountData) {

            Console.WriteLine($"[argument] = {encryptedAccountData}");

            string decodedUrlEncodingData = WebUtility.UrlDecode(encryptedAccountData.Replace("[P]", "%"));
            string decryptedAccountData = System.Services.Cryptography.decryptAccountData(decodedUrlEncodingData);

            return decryptedAccountData;

            JObject decryptedJson = JsonConvert.DeserializeObject(decryptedAccountData) as JObject;

            string email = decryptedJson["email"].Value<string>();
            string password = decryptedJson["password"].Value<string>();

            Console.WriteLine($"[decrypted email] = {email} [decrypted password] = {password}");

            HttpClient httpClient = new HttpClient();
            string url = "https://jobrecruitmentapi.azurewebsites.net/api/Register?code=D/8y4FRnQDqvFqRIcEoWwzGiKFXk09at7wuT0zg66DFNXlDO4GixdQ==";
           // HttpResponseMessage response = await httpClient.GetAsync($"{url}&email={email}&password={password}");

        //    Console.WriteLine(response);

            return $"Email= {email} \nPassword= {password}";
        }
    }
}