using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KJobRecruitmentWebApp.Data
{
    public static class User
    {
        public class AccountData
        {
            public string uid { get; set; }
            public string email { get; set; }
            public string role { get; set; }
            public string last_login { get; set; }
            public string created_date { get; set; }
            public bool notif_all { get; set; }
            public bool notif_email { get; set; }
            public bool notif_news { get; set; }
            public bool notif_interested { get; set; }
        }

        public class ProfileData
        {
            public string personal_id { get; set; }
            public string thai_name { get; set; }
            public string eng_name { get; set; }
            public string date_of_birth { get; set; }
            public string nationality { get; set; }
            public string race { get; set; }
            public string religion { get; set; }
            public string blood { get; set; }
            public string relationship { get; set; }
            public string child { get; set; }
            public string military_criterion { get; set; }
            public string address { get; set; }
            public string province { get; set; }
            public string telephone { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
        }

        public class CandidateData
        {
            public string candidate_id { get; set; }
            public string status { get; set; }
            public string extar_info { get; set; }
            public string applied_id { get; set; }

        }

        public static async Task<AccountData> GetAccount(string uid) {

            string response = await System.Services.ApiInterfacer.GetUser("Account", uid);
            Console.WriteLine($"get user account response {response}");
            return JsonConvert.DeserializeObject<AccountData>(response);
        }

        public static async Task<ProfileData> GetProfile(string uid)
        {

            string response = await System.Services.ApiInterfacer.GetUser("Profile", uid);
            Console.WriteLine($"get user account response {response}");
            return JsonConvert.DeserializeObject<ProfileData>(response);
        }

        public static async Task<CandidateData> GetCandidateData(string uid) {

            string response = await System.Services.ApiInterfacer.GetCandidate(uid);

            Console.WriteLine(response);

            return JsonConvert.DeserializeObject<CandidateData>(response);
        }
    }
}
