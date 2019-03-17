using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJobRecruitmentWebApp.Models
{
    public class LoginModel
    {

        public static async Task<string> TryLogin(string email, string password) {

            string response = await System.Services.ApiInterfacer.Login(email, password);

            return response;
        }
    }
}
