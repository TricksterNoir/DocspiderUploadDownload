using Dapper;
using Infra.Data.Contracts;
using Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Infra.Data.Repositories
{
    public class UploadRepository : IUploadRepository
    { 
        private readonly string connectionString;

        //construtor para entrada de argumentos
        public UploadRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Inserir(Upload obj)
        {
            var query = "insert into Upload(IdUpload,Titulo,Descricao,Arquivo,Nome_Do_Arquivo,DataCriacao) "
                    + "values(@IdUpload, @Titulo, @Descricao, @Arquivo, @Nome_Do_Arquivo, @DataCriacao)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }
        public void Atualizar(Upload obj)
        {
            var query = "update Upload(IdUpload,Titulo,Descricao,Arquivo,Nome_Do_Arquivo,DataCriacao)"
                      + "where IdCliente = @IdUpload";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }
        public void Excluir(Upload obj)
        {
            var query = "delete from Upload where IdUpload = @IdUpload";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }

        public List<Upload> Consultar()
        {
            try
            {
                var query = "select * from Upload";

                using (var connection = new SqlConnection(connectionString))
                {
                    var teste = connection.Query<Upload>(query).ToList();
                    return connection.Query<Upload>(query).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
         
        }


    }
}
