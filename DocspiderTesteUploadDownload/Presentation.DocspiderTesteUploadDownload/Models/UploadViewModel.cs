using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DocspiderTesteUploadDownload.Models
{
    public class UploadViewModel
    {
        public int IdUpload { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o Titulo!")]
        [MaxLength(100,ErrorMessage = "O campo Titulo deve conter no máximo 100 caracteres.")]
         public string Titulo { get; set; }

        [MaxLength(2000, ErrorMessage = "O campo Descrição deve conter no máximo 2000 caracteres.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, selecione o Arquivo!")]
        public Microsoft.AspNetCore.Http.IFormFile Arquivo { get; set; }

        [Required(ErrorMessage = "Por favor, preencha o Nome Do Arquivo!")]
        public string Nome_Do_Arquivo { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
