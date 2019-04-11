using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KJobRecruitmentWebApp.Data;
using Rotativa.AspNetCore;

namespace KJobRecruitmentWebApp.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Index() => new Rotativa.AspNetCore.ViewAsPdf();

        public IActionResult DownloadActionAsPDF()
        {
            return new Rotativa.AspNetCore.ViewAsPdf() { FileName = "PDF.pdf" };
        }
        public async Task<IActionResult> resume(string id)
        {
            Data.User.ProfileData profile = await Data.User.GetProfile(id);
            ViewData["ProfielData"] = profile;
            //Data.User.ProfileData profile = await Data.User.GetProfile("9d67fd4b-5736-4ed3-b2ef-e57955c84201");
            ViewData["TEST"] = "TEST";
            return new ViewAsPdf(ViewData);
        }
    }
}