using DocspiderTesteUploadDownload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocspiderTesteUploadDownload.Services{
    public class UploadService{
        public static List<Upload> GetUpload()
        {
            var _uploads = new List<Upload>()
            {
                new Upload { Id_Upload=1, Arquivo=null, Nome_Do_Arquivo="Teste", Titulo= "TituloTeste", Descricao="Isso e um teste",DataArquivo=DateTime.Now},
                new Upload { Id_Upload=2, Arquivo=null, Nome_Do_Arquivo="Teste2", Titulo= "TituloTeste2", Descricao="Isso e um teste2",DataArquivo = DateTime.Now},
};
            return _uploads;
        }
    }
}
