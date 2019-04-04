using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace KJobRecruitmentWebApp.Controllers
{
    public class PdfController : Controller
    {
        public IActionResult Index() => new Rotativa.AspNetCore.ViewAsPdf();

        public IActionResult DownloadActionAsPDF()
        {
            return new Rotativa.AspNetCore.ViewAsPdf() { FileName = "PDF.pdf" };
        }
    }
}