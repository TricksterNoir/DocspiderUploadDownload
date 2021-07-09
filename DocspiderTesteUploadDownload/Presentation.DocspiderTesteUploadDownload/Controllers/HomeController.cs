using Infra.Data.Contracts;
using Infra.Data.Entities;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DocspiderTesteUploadDownload.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUploadRepository _uploadRepository;
        public HomeController(IUploadRepository uploadRepository)
        {
            _uploadRepository = uploadRepository;
        }
        public IActionResult Index()
        {
            List<Upload> model = _uploadRepository.Consultar();
            ViewData["Upload"] = model;
            return View();
        }

        public IActionResult CadastroAlteracao()
        {
            return View();
        }

        public IActionResult Excluir(int id)
        {
            return RedirectToAction("Index");
        }
    }
}
