using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    public class AccountController : Controller
    {
        public string GetEmail() {
            return ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email).ToString();
        }

        public string GetUid() {
            return ((ClaimsIdentity)User.Identity).FindFirst("Uid").ToString();
        }

        public string GetRole() {
            return ((ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Role).ToString();
        }
    }
}