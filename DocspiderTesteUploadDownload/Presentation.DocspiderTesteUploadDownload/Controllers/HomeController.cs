using Infra.Data.Contracts;
using Infra.Data.Entities;
using Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> CadastroAlteracao(UploadViewModel upload)
        {
            byte[] arquivoAntigo = null;
            string contentTypeAntigo = null;
            if (upload.IdUpload != 0 && upload.Arquivo == null)
            {
                Upload novoUpload =  await _uploadRepository.ConsultarPorId(upload.IdUpload);
                arquivoAntigo = novoUpload.Arquivo;
                contentTypeAntigo = novoUpload.ContentType;
            }

            if(upload.IdUpload == 0 && upload.Arquivo == null)
            {
                ViewBag.Upload = upload;
                ViewBag.ErroArquivo = "*Arquivo e Nome do Arquivo são obrigatórios";
                
                return View();
            }


           
                        
            if (ModelState.IsValid)
            {
               
                string nomeArquivo = upload.Nome_Do_Arquivo;
                var ext = Path.GetExtension(upload.Nome_Do_Arquivo);

                if (ext == "")
                {
                    nomeArquivo = upload.Nome_Do_Arquivo + Path.GetExtension(upload.Arquivo.FileName);
                }   

                Upload arquivo = await _uploadRepository.ConsultarPorNomeArquivo(upload.Titulo, nomeArquivo, upload.IdUpload);

                if (arquivo != null)
                {
                    ViewBag.Upload = upload;
                    ViewBag.Erro = "*Título ou nome do arquivo já cadastrado";
                    return View();
                }
                else
                {
                  
                    if (arquivoAntigo == null)
                    {
                        Files file = this.FileUpload(upload.Arquivo, upload.Nome_Do_Arquivo);
                        arquivoAntigo = file.DataFiles;
                        contentTypeAntigo = file.ContentType;
                    }
                   

                    Upload Novo = new Upload(upload.IdUpload, upload.Titulo, upload.Descricao,
                                             arquivoAntigo, nomeArquivo,
                                             upload.DataCriacao, contentTypeAntigo);

                    if (upload.IdUpload == 0)
                    {
                        _uploadRepository.Inserir(Novo);
                    }
                    else
                    {
                        _uploadRepository.Atualizar(Novo);
                    }

                }                
            }
            else
            {
                ViewBag.Upload = upload;
                return View();
            }
            return RedirectToAction("Index");
        }
        public async Task<FileResult> DownloadFile(int id)
        {
            Upload model = await _uploadRepository.ConsultarPorId(id);
           string fileName = model.Nome_Do_Arquivo;
            string contentType = model.ContentType;
            byte[] bytes = model.Arquivo;
            return File(bytes, contentType, fileName);
        }

        public Files FileUpload(IFormFile file, string nomeArquivo )
        {
            
           
            
            string type = file.ContentType;
            byte[] bytes = null;
            using (MemoryStream ms = new MemoryStream())
            {
                file.CopyTo(ms);
                bytes = ms.ToArray();
            }

            return new Files(file.FileName, type, bytes);
        }
    }

  
}
