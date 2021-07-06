using System;
namespace DocspiderTesteUploadDownload.Models{
    public class Upload{
        public int Id_Upload { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Arquivo { get; set; }
        public string Nome_Do_Arquivo { get; set; }
        public DateTime DataArquivo { get; set; }
    }
}