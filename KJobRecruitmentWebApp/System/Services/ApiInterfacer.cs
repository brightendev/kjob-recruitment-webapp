using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace KJobRecruitmentWebApp.System.Services
{
    static class ApiInterfacer
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string apiServer = "https://jobrecruitmentapi.azurewebsites.net/";

        public static async Task<string> CallCreateAccount(string email, string password) {

            string endpoint = "api/Register?code=D/8y4FRnQDqvFqRIcEoWwzGiKFXk09at7wuT0zg66DFNXlDO4GixdQ==";

            HttpResponseMessage response = await httpClient.GetAsync($"{apiServer}{endpoint}&email={email}&password={password}");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
