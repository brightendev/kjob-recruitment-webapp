using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
