using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        // for firstlogin
        public static async Task<string> GetAllProvince() {

            string endpoint = "api/Province?code=hMTHLO8G9GAzkjqmBi3z5W4rBnAfHO282SE2SSoxWYF3g/TCQcQSAA==";

            string response = await httpClient.GetStringAsync($"{apiServer}{endpoint}");

            return response;
        }

        // for first login
        public static async Task<string> GettAllBloodType() {

            string endpoint = "api/Blood?code=KvM4oYKc2lrOeWbY9W80I3T/fSwzE8DpW3w1JYadL5QeRLyvah621A==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}");
        }

        public static async Task<string> GetPublicData() {

            string endpoint = "api/GetPublicData?code=Ry8wyMHcMEplaWYfO2tAh3n42BQ4Nx/hr8oItCAlCBt6518/1Ma8Cg==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}");
        }

        public static async Task<string> CreateProfile(string uid, string personalId, string thaiName, string engName, string birthDate, string nationality,
        string race, string religion, string blood, string relationship, string child, string militaryCriterion, string address, string province,
        string phone, string email, string gender) {

            string endpoint = "api/CreateProfile";

            /*    string queryString =
                    $"&owner_uid={uid}&personal_id={personalId}&thai_name={thaiName}&eng_name={engName}&date_of_birth={birthDate}&nationality={nationality}" +
                    $"&race={race}&religion={religion}&blood={blood}&relationship={relationship}&child={child}&military_criterion={militaryCriterion}" +
                    $"&address={address}&province={province}&telephone={phone}&email={email}&gender={gender}";

                return await httpClient.GetStringAsync($"{apiServer}{endpoint}{queryString}");*/

            HttpContent requestContent = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "code", "clBi3gTWPt/kIxmZRDmVYE0gQGXp7XrV6aeJbVx5U8isqZuOkvHAcg==" },
                { "personal_id", personalId },
                { "thai_name", thaiName },
                { "eng_name", engName },
                { "date_of_birth", birthDate },
                { "nationality", nationality },
                { "race", race },
                { "religion", religion },
                { "blood", blood },
                { "relationship", relationship },
                { "child", child },
                { "military_criterion", militaryCriterion },
                { "address", address },
                { "province", province },
                { "telephone", phone },
                { "email", email },
                { "owner_uid", uid },
                { "gender", gender },
            });

         /*   HttpResponseMessage response = await httpClient.GetAsync(endpoint, requestContent);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                return await response.Content.ReadAsStringAsync();
            }*/
            string queryString = await requestContent.ReadAsStringAsync();
            string url = $"{apiServer}{endpoint}?{queryString}";
            Console.WriteLine(url);
            return await httpClient.GetStringAsync(url);
        }


        // ========= for user editting =========
        public static async Task<string> SetAccountNotitification(string setting, string uid, string value) {

            string endpoint = "api/EditUser?code=Qd1JLijvQJaRHNqfuh8wP2LV8R2sKstHzm8TGh63EH0X5evwr1ODRA==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}&edit={setting}&value={value}&uid={uid}");

        }

        // =============== for user getting data ===============
        public static async Task<string> GetUser(string get, string uid) {

            string endpoint = "api/GetUser?code=7WXYhlgle9QfWd25hfjnDfmMufg9nSZPmlMl/KI5UWDSXFLdCquv7A==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}&get={get}&uid={uid}");
        }


        // ============ for dashboard =========
        public static async Task<string> GetAllAccounts(string requester) {

            string endpoint = "api/GetAccount?code=VbIN697ivYftiNFoIfkYwqrCJWuonDFpbmpS5rMd1GvOrpRBlgPBaQ==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}&email={requester}");
        }

        public static async Task<string> GetRole(string uid) {
            string endpoint = "api/CheckRole?code=AgRLo6QagYEItNSm1yAboxOdrxmo5fgqiOBwOITPEblXF3GgOQ6TlA==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}&uid={uid}");
        }


        //================= for Job board ================
        public static async Task<string> GetJob(string job)
        {
            string endpoint = "api/GetJob?code=9qNWS6sYtq/ejXJQ110PxrnYaAmT6SGuyePq96hVTnbO4Pl2U2wLCw==";

            return await httpClient.GetStringAsync($"{apiServer}{endpoint}&job={job}");
        }
    }
}
