using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Contracts
{
    public interface IBaseRepository<T> where T : class 
    {
        void Inserir(T obj);
        void Atualizar(T obj);
        void Excluir(int id);
        Task<T> ConsultarPorId(int Id);
        List<T> Consultar();

        Task<T> ConsultarPorNomeArquivo(string titulo, string nome, int id);
    }
}
