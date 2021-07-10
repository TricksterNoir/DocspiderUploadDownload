using Dapper;
using Infra.Data.Contracts;
using Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            obj.DataCriacao = DateTime.Now;
            var query = "insert into Upload(Titulo,Descricao,Arquivo,Nome_Do_Arquivo,DataCriacao) "
                    + "values(@Titulo, @Descricao, @Arquivo, @Nome_Do_Arquivo, @DataCriacao)";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }
        public void Atualizar(Upload obj)
        {
            var query = "update Upload "
                 + "set titulo = @Titulo, descricao = @Descricao, arquivo = @Arquivo, nome_do_arquivo = @Nome_Do_Arquivo "
                 + "where IdUpload = @IdUpload";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, obj);
            }
        }
        public void Excluir(int id)
        {
            var query = "delete from Upload where IdUpload = "+id;

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Execute(query, id);
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

        public async Task<Upload> ConsultarPorId(int Id)
        {
            try
            {
                var query = "select * from Upload where idupload = "+Id;

                using (var connection = new SqlConnection(connectionString))
                {
                    var teste = await connection.QueryFirstAsync<Upload>(query);
                    return teste; //await (Upload)connection.QueryFirstAsync<Upload>(query);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


    }
}
