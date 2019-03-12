using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace KJobRecruitmentWebApp.Core
{
    static class Register
    {

        public static void CreateAccount(string email, string password)
        {

            Console.WriteLine($"received email and password {email} , {password}");

            string cipher = encryptAccountData((JsonConvert.SerializeObject(new { email, password })));

            Console.WriteLine($"encrypted : {cipher}");

            Console.WriteLine($"decrypted : {decryptAccountData(cipher)}");

            sendConfirmationEmail(cipher);

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


        private static async void sendConfirmationEmail(string url)
        {
       /*     var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("dx@example.com", "SendGrid DX Team"));

            var recipients = new List<EmailAddress>
            {
                new EmailAddress("s5903051613102@email.kmutnb.ac.th", "Jeff Smith"),
                new EmailAddress("cadetmetsak@gmail.com", "Anna Lidman"),
            };
            msg.AddTos(recipients);

            msg.SetSubject("Testing the SendGrid C# Library");

            msg.AddContent(MimeType.Text, "Hello World plain text!");
            msg.AddContent(MimeType.Html, "<p>Hello World!</p>");*/



            var apiKey = "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";
            var client = new SendGridClient(apiKey);

            string mail = "";

            var msg = new SendGridMessage()
            {
                From = new EmailAddress("kjobrecruitment@gacdevelopment", "KJob Recruitment"),
                Subject = "Hello World from the SendGrid CSharp SDK!",
                PlainTextContent = "Hello, Email!",
                HtmlContent = $"<strong>Hello, Email! {url}</strong>"
            };
            msg.AddTo(new EmailAddress("cadetmetsak@gmail.com", "Test User"));
            var response = await client.SendEmailAsync(msg);
        }
    }
}
