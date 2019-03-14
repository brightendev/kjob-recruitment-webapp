using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace KJobRecruitmentWebApp.Models
{
    static class RegisterModel
    {
        public static void CreateAccount(string email, string password)
        {
            Console.WriteLine($"received email and password {email} , {password}");

            string accountCipher = encryptNewAccountData(email, password);
         //   accountCipher = accountCipher.Replace("%", "[P]");

            Console.WriteLine($"encrypted : {accountCipher}");
            Console.WriteLine($"decrypted : {System.Services.Cryptography.DecryptString(accountCipher)}");

            string acceptedFormatString = WebUtility.UrlEncode(accountCipher).Replace("%", "[P]");

            sendConfirmationEmail(email, acceptedFormatString);

        }

        private static string encryptNewAccountData(string email, string password)
        {

            return System.Services.Cryptography.EncryptString((JsonConvert.SerializeObject(new { email, password })));
        }

    //    private static string generate

        private static void sendConfirmationEmail(string email, string encryptedConfirmationData) {

            using (StreamReader reader = File.OpenText("./wwwroot/email_template/register_account.html"))
            {
                string emailTemplate = reader.ReadToEnd().Replace("{{action_url}}", $"https://kjobrecruitment.azurewebsites.net/{encryptedConfirmationData}callapicreateaccount");
                System.Services.Email.SendHtmlEmail(email, "kuykuykuy", "ยืนยัน Email", emailTemplate);
            }
        }

        public static async Task<string> ResponseToConfirmationEmail(string encryptedConfirmationData) {

            Console.WriteLine($"[argument] = {encryptedConfirmationData}");

            string decodedUrlEncodingData = WebUtility.UrlDecode(encryptedConfirmationData.Replace("[P]", "%"));
            string decryptedAccountData = System.Services.Cryptography.DecryptString(decodedUrlEncodingData);

            JObject decryptedJson = JsonConvert.DeserializeObject(decryptedAccountData) as JObject;

            string email = decryptedJson["email"].Value<string>();
            string password = decryptedJson["password"].Value<string>();

            Console.WriteLine($"[decrypted email] = {email} [decrypted password] = {password}");

        //    HttpClient httpClient = new HttpClient();
       //     string url = "https://jobrecruitmentapi.azurewebsites.net/api/Register?code=D/8y4FRnQDqvFqRIcEoWwzGiKFXk09at7wuT0zg66DFNXlDO4GixdQ==";
            // HttpResponseMessage response = await httpClient.GetAsync($"{url}&email={email}&password={password}");

            //    Console.WriteLine(response);

            return await System.Services.ApiInterfacer.CallCreateAccount(email, password);

            //   return "";
        }

    }
}
