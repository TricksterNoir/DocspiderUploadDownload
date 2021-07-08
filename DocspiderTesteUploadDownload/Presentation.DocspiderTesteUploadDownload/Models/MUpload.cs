using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.DocspiderTesteUploadDownload.Models
{
    public class MUpload
    {
        public int Id_Upload { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte Arquivo { get; set; }
        public string Nome_Do_Arquivo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
