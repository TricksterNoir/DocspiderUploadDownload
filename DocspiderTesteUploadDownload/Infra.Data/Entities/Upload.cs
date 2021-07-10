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
        public byte[] Arquivo { get; set; }
        public string ContentType { get; set; }
        public string Nome_Do_Arquivo { get; set; }
        public DateTime DataCriacao { get; set; }
        public Upload(int IdUpload, string Titulo, string Descricao, byte[] Arquivo, string Nome_Do_Arquivo, DateTime DataCriacao, string ContentType)
        {
            this.IdUpload = IdUpload;
            this.Titulo = Titulo;
            this.Descricao = Descricao;
            this.Arquivo = Arquivo;
            this.Nome_Do_Arquivo = Nome_Do_Arquivo;
            this.DataCriacao = DataCriacao;
            this.ContentType = ContentType;
        }
        public Upload()
        {

        }
    }
}
