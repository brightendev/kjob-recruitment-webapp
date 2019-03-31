using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            Console.WriteLine("try to login" + acc.email);
            string response = await LoginModel.TryLogin(acc.email, acc.password);

            if(response.Contains("error")) {
                Console.WriteLine("Login Error");
                return Redirect("/login");
            }

            Console.WriteLine(response);

            ClaimsIdentity identity = LoginModel.ClaimIdentity(response);

            Authorize(identity);
            Console.WriteLine("sign in success with email: "+acc.email);

            return Redirect("/");
        }

        private async void Authorize(ClaimsIdentity identity) {

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                }
            );

            User.AddIdentity(identity);
        }

        public class FirstloginData
        {
            public string personalId { get; set; }

            public string gender { get; set; }

            public string thaiName { get; set; }

            public string thaiLasrName { get; set; }

            public string engName { get; set; }

            public string engLastName { get; set; }

            public string birthDate { get; set; }

            public string blood { get; set; }

            public string militaryCriterion { get; set; }

            public string religion { get; set; }

            public string relationship { get; set; }

            public string child { get; set; }


            public string race { get; set; }

            public string nationality { get; set; }

            public string address { get; set; }

            public string province { get; set; }

            public string phone { get; set; }

        }

        [Authorize(Roles = "Candidate")]
        public async Task<ActionResult> FirstLogin() {

        /*    List<Data.ExternalDatabase.BloodTypeData> bloodTypeDataList = await Data.ExternalDatabase.GetAllBloodTypeData();
            List<SelectListItem> bloodTypeSelectList = bloodTypeDataList.Select(provinceData => new SelectListItem() { Text = provinceData.blood_name, Value = provinceData.blood_id }).ToList();
            bloodTypeSelectList.Insert(0, new SelectListItem() { Text = "- เลือกกรุ๊ปเลือด -" , Value = "0"});
            ViewData["BloodTypes"] = bloodTypeSelectList;

            List<Data.ExternalDatabase.ProvinceData> provinceDataList = await Data.ExternalDatabase.GetProvinceData();

            List<SelectListItem> provinceSelectList = provinceDataList.Select(provinceData => new SelectListItem() { Text = provinceData.province_name, Value = provinceData.province_id }).ToList();
            provinceSelectList.Insert(0, new SelectListItem() { Text = "- เลือกจังหวัด -", Value = "0" });
            ViewData["Provinces"] = provinceSelectList;
            */

            
            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            string newUser = await System.Services.ApiInterfacer.IsAccountHasProfile(uid);

            Console.WriteLine($"is account have profile = {newUser}");

            if(newUser.Equals("HAVE")) {
                return Redirect("/");
            }

            Data.ExternalDatabase.PublicData data = await Data.ExternalDatabase.GetPublicData();
            ViewData["BloodList"] = data.Blood;
            ViewData["ReligionList"] = data.Religion;
            ViewData["Relationship"] = data.Relationship;
            ViewData["MilitaryCriterionList"] = data.MilitaryCriterion;
            ViewData["ProvinceList"] = data.Province;
            ViewData["GenderList"] = data.Gender;

            return View();
        }

        [Authorize(Roles = "Candidate")]
        [HttpPost]
        public async Task<string> Firstlogin(FirstloginData profile)
        {
            Console.WriteLine(profile.personalId);
            Console.WriteLine(profile.thaiName);
            Console.WriteLine(profile.thaiLasrName);
            Console.WriteLine(profile.engName);
            Console.WriteLine(profile.engLastName);
            Console.WriteLine(profile.birthDate);
            Console.WriteLine(profile.nationality);
            Console.WriteLine(profile.race);
            Console.WriteLine(profile.religion);
            Console.WriteLine(profile.blood);
            Console.WriteLine(profile.relationship);
            Console.WriteLine(profile.child);
            Console.WriteLine(profile.militaryCriterion);
            Console.WriteLine(profile.address);
            Console.WriteLine(profile.province);
            Console.WriteLine(profile.phone);
            Console.WriteLine(profile.gender);

            string uid = HttpContext.Session.GetString(System.SessionVariable.uid);
            string email = HttpContext.Session.GetString(System.SessionVariable.email);
            string creatingProfileResult = await System.Services.ApiInterfacer.CreateProfile(uid, profile.personalId, $"{profile.thaiName} {profile.thaiLasrName}", 
                $"{profile.engName} {profile.engLastName}", profile.birthDate, profile.nationality, profile.race, profile.religion, profile.blood,
                profile.relationship, profile.child, profile.militaryCriterion, profile.address, profile.province, profile.phone, email, profile.gender);

            return creatingProfileResult;
        }
    }
}