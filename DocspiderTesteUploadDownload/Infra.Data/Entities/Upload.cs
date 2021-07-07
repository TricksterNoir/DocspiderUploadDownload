using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Entities
{
    public class Upload
    {
        public int IdUpload { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public byte Arquivo { get; set; }
        public string Nome_Do_Arquivo { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
