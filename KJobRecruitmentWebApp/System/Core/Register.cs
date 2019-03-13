using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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

            string cipher = Services.Cryptography.encryptAccountData((JsonConvert.SerializeObject(new { email, password })));

            Console.WriteLine($"encrypted : {cipher}");

            Console.WriteLine($"decrypted : {Services.Cryptography.decryptAccountData(cipher)}");

            using (StreamReader reader = File.OpenText("./wwwroot/email_template/register_account.html")) {
                string emailTemplate = reader.ReadToEnd().Replace("{{action_url}}", "http://www.google.com");
                System.Services.Email.SendHtmlEmail(email, "kuykuykuy", "ยืนยัน Email", emailTemplate);
            }

        }


    }
}
