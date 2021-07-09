using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Data.Contracts
{
    public interface IBaseRepository<T> where T : class 
    {
        void Inserir(T obj);
        void Atualizar(T obj);
        void Excluir(T obj);

        List<T> Consultar();
    }
}
