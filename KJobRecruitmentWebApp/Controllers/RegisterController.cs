﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KJobRecruitmentWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace KJobRecruitmentWebApp.Controllers
{
    public class RegisterController : Controller
    {
        public class SubmitData
        {
            public string email { get; set; }
            public string password { get; set; }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SubmitData acc)
        {

            RegisterModel.CreateAccount(acc.email, acc.password);

            return View();
        }
    }
}