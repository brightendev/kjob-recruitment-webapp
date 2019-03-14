using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KJobRecruitmentWebApp.System.Services
{
    static class Cryptography
    {
        private static readonly string hash = "a0-9!fdf_?.ser@#";

        public static string EncryptString(string accData)
        {

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

        public static string DecryptString(string accData)
        {

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
