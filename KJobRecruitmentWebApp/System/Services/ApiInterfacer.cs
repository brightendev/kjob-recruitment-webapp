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

        public static async Task<string> Login(string email, string password) {

            string endpoint = "api/Login?code=b/QZfneK7bYJAe46OigxQ8zLegWx3aI9Ka8J9W4qE4jpHkBlrwUt3Q==";

            string response = await httpClient.GetStringAsync($"{apiServer}{endpoint}&email={email}&password={password}");

            return response;
        } 
    }
}
