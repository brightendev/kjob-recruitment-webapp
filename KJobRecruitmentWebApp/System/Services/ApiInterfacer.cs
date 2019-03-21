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

            return await response.Content.ReadAsStringAsync();//
        }

        public static async Task<string> Login(string email, string password) {

            string endpoint = "api/Login?code=b/QZfneK7bYJAe46OigxQ8zLegWx3aI9Ka8J9W4qE4jpHkBlrwUt3Q==";

            string response = await httpClient.GetStringAsync($"{apiServer}{endpoint}&email={email}&password={password}");

            return response;
        }

        public static async Task<string> IsAccountHasProfile(string uid) {

            string endpoint = "api/CheckProfile?code=55p1Ms9s86VbaDR63oSBIyhqDYfYxv7CZjJSWuvMgqUZrAregJLMbA==";

            string response = await httpClient.GetStringAsync($"{apiServer}{endpoint}&uid={uid}");

            return response;
        }

        public static async Task<string> GetAllProvince() {

            string endpoint = "api/Province?code=hMTHLO8G9GAzkjqmBi3z5W4rBnAfHO282SE2SSoxWYF3g/TCQcQSAA==";

            string response = await httpClient.GetStringAsync($"{apiServer}{endpoint}");

            return response;
        }

        public static async Task<string> GettAllBloodType() {

            string endpoint = "api/Blood?code=KvM4oYKc2lrOeWbY9W80I3T/fSwzE8DpW3w1JYadL5QeRLyvah621A==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}");
        }
    }
}
