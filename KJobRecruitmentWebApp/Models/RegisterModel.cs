using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KJobRecruitmentWebApp.Models
{
    static class RegisterModel
    {
        public static void CreateAccount(string email, string password) {

            System.Core.Register.CreateAccount(email, password);

        }
    }
}
