using Infra.Data.Contracts;
using Infra.Data.Entities;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Presentation.DocspiderTesteUploadDownload.Models;
using System;
using System.Collections.Generic;
using System.IO;
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

        public async Task<IActionResult> CadastroAlteracao(int id)
        {
            if (id != 0)
            {
                Upload upload = await _uploadRepository.ConsultarPorId(id);
                ViewBag.Upload = upload;
            }
            else
                {
                ViewBag.Upload = new Upload();
            }
            return View();
         }

        public IActionResult Excluir(int id)
        {
            if (id != 0)
            {
                _uploadRepository.Excluir(id);
            }
            return RedirectToAction("Index");
        }
 
        [HttpPost]
        public IActionResult CadastroAlteracao(UploadViewModel upload)
        {
            if (ModelState.IsValid)
            {
                //Getting FileName
                var fileName = Path.GetFileName(upload.Arquivo.FileName);
                //Getting file Extension
                var fileExtension = Path.GetExtension(fileName);
                // concatenating  FileName + FileExtension
                var newFileName = String.Concat(Convert.ToString(Guid.NewGuid()), fileExtension);

                var objfiles = new Files()
                {
                    Name = newFileName,
                    FileType = fileExtension,
                    CreatedOn = DateTime.Now
                };

                using (var target = new MemoryStream())
                {
                    upload.Arquivo.CopyTo(target);
                    objfiles.DataFiles = target.ToArray();
                }

            Upload Novo = new Upload(upload.IdUpload,upload.Titulo,upload.Descricao,objfiles.DataFiles, upload.Nome_Do_Arquivo,upload.DataCriacao);
                if (upload.IdUpload == 0)
                {
                    _uploadRepository.Inserir(Novo);
                }
                else
                {
                    _uploadRepository.Atualizar(Novo);
                }
            }
            else
            {
                ViewBag.Upload = upload;
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
