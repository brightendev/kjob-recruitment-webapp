using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KJobRecruitmentWebApp.Data
{
    static class User
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

        public static async Task<AccountData> GetAccount(string uid) {

            string response = await System.Services.ApiInterfacer.GetUser("Account", uid);
            Console.WriteLine($"get user account response {response}");
            return JsonConvert.DeserializeObject<AccountData>(await System.Services.ApiInterfacer.GetUser("Account", uid));
        }
    }
}
