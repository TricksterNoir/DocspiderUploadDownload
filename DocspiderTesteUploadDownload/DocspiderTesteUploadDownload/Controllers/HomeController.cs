using DocspiderTesteUploadDownload.Models;
using DocspiderTesteUploadDownload.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DocspiderTesteUploadDownload.Controllers
{
    public class HomeController : Controller
    {
        List<Upload> upload = UploadService.GetUpload();

        public ActionResult Index()
        {
            return View(upload);
        }

        public ActionResult Incluir()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}