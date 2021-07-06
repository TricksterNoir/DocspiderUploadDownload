using System;
using System.Web;

namespace DocspiderTesteUploadDownload.Models{
    public class Upload{
        public int Id_Upload { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public HttpPostedFileBase Arquivo { get; set; }
        public string Nome_Do_Arquivo { get; set; }
        public DateTime DataArquivo { get; set; }
    }
}