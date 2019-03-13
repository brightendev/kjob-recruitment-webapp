﻿using System;
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

            string cipher = encryptAccountData((JsonConvert.SerializeObject(new { email, password })));

            Console.WriteLine($"encrypted : {cipher}");

            Console.WriteLine($"decrypted : {decryptAccountData(cipher)}");

            using (StreamReader reader = File.OpenText("./wwwroot/email_template/register_account.html"))  
            {
                System.Services.Email.SendHtmlEmail(email, "kuykuykuy", "ยืนยัน Email", reader.ReadToEnd());
            }

        }

        private static string encryptAccountData(string accData)
        {

            string hash = "afdfser@#";

            byte[] data = UTF8Encoding.UTF8.GetBytes(accData);

            string result = "";

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {

                byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider()
                {
                    Key = key,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripleDes.CreateEncryptor();
                    byte[] output = transform.TransformFinalBlock(data, 0, data.Length);

                    result = Convert.ToBase64String(output);
                }
            }

            return result;
        }

        private static string decryptAccountData(string accData)
        {
            Console.WriteLine("Send Confirmation email has been called");

            string hash = "afdfser@#";

            byte[] data = Convert.FromBase64String(accData);

            string result = "";

            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {

                byte[] key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(hash));

                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider()
                {
                    Key = key,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                })
                {
                    ICryptoTransform transform = tripleDes.CreateDecryptor();
                    byte[] output = transform.TransformFinalBlock(data, 0, data.Length);

                    result = UTF8Encoding.UTF8.GetString(output);
                }
            }

            return result;
        }

    }
}
