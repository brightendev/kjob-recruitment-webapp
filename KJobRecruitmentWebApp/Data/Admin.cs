using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KJobRecruitmentWebApp.Data
{
    public static class Admin
    {
        public class Account
        {
            public string email { get; set; }
            public string last_login { get; set; }
            public string role_name { get; set; }
        }

        public static async Task<List<Account>> GetAllAccounts(string email)
        {
            Console.WriteLine($"=== requester email = {email}");
            Console.WriteLine((await System.Services.ApiInterfacer.GetAllAccounts(email))+" sssssssssssss");
            return JsonConvert.DeserializeObject<List<Account>>(await System.Services.ApiInterfacer.GetAllAccounts(email));
        }
    }
}
