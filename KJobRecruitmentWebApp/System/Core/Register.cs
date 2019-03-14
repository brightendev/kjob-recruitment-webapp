using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace KJobRecruitmentWebApp.System.Core
{
    static class Register
    {

        public static void CreateAccount(string email, string password)
        {
            Console.WriteLine($"received email and password {email} , {password}");

            string accountCipher = EncryptNewAccountData(email, password);
            accountCipher = accountCipher.Replace("%", "[P]");

            Console.WriteLine($"encrypted : {accountCipher}");
            Console.WriteLine($"decrypted : {Services.Cryptography.DecryptString(accountCipher)}");

            string acceptedFormatString = WebUtility.UrlEncode(accountCipher).Replace("%", "[P]");

            using (StreamReader reader = File.OpenText("./wwwroot/email_template/register_account.html")) {
                string emailTemplate = reader.ReadToEnd().Replace("{{action_url}}", $"https://kjobrecruitment.azurewebsites.net/{acceptedFormatString}callapicreateaccount");
                System.Services.Email.SendHtmlEmail(email, "kuykuykuy", "ยืนยัน Email", emailTemplate);
            }

        }

        private static string EncryptNewAccountData(string email, string password) {

            return Services.Cryptography.EncryptString((JsonConvert.SerializeObject(new { email, password })));
        }


    }
}
