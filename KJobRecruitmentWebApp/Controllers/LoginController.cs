using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Controllers
{
    public class LoginController : Controller
    {
        public class LoginData
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginData acc) {

            string response = await LoginModel.TryLogin(acc.email, acc.password);

            if(response.Contains("error")) return Redirect("login");

            Console.WriteLine(response);

            ClaimsIdentity identity = LoginModel.ClaimIdentity(response);

            Authorize(identity);

            return Redirect("/");
        }

        private async void Authorize(ClaimsIdentity identity) {

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddSeconds(30)
                }
            );

            User.AddIdentity(identity);
        }

        public class FirstloginData
        {
            public string idCard { get; set; }

            public string username { get; set; }

            public string userlastname { get; set; }

            public string usernameEng { get; set; }

            public string userlastnameEng { get; set; }

            public string Birth { get; set; }

            public string nationality { get; set; }

            public string race { get; set; }

            public string religion { get; set; }

            public string bloodtype { get; set; }

            public string relationship { get; set; }

            public string childrenNum { get; set; }

            public string militaryStatus { get; set; }

            public string address { get; set; }

            public string province { get; set; }

            public string phoneNumber { get; set; }

        }

        
        public async Task<ActionResult> FirstLogin() {

            List<Data.ExternalDatabase.BloodTypeData> bloodTypeDataList = await Data.ExternalDatabase.GetAllBloodTypeData();
            List<SelectListItem> bloodTypeSelectList = bloodTypeDataList.Select(provinceData => new SelectListItem() { Text = provinceData.blood_name, Value = provinceData.blood_id }).ToList();
            bloodTypeSelectList.Insert(0, new SelectListItem() { Text = "- เลือกกรุ๊ปเลือด -" , Value = "0"});
            ViewData["BloodTypes"] = bloodTypeSelectList;

            List<Data.ExternalDatabase.ProvinceData> provinceDataList = await Data.ExternalDatabase.GetProvinceData();

            List<SelectListItem> provinceSelectList = provinceDataList.Select(provinceData => new SelectListItem() { Text = provinceData.province_name, Value = provinceData.province_id }).ToList();
            provinceSelectList.Insert(0, new SelectListItem() { Text = "- เลือกจังหวัด -", Value = "0" });
            ViewData["Provinces"] = provinceSelectList;

            return View();
        }

        [HttpPost]
        public ActionResult Firstlogin(FirstloginData acc)
        {
            Console.WriteLine(acc.idCard);
            Console.WriteLine(acc.idCard);
            Console.WriteLine(acc.idCard);
            Console.WriteLine(acc.idCard);
            return Redirect("/");
        }
    }
}