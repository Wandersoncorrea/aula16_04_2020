using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.DAOs.Interfaces
{
    public interface IBebidaDAO
    {
        long Cadastrar(Bebida bebida);
        Bebida Obter(long id);
        IEnumerable<Bebida> ObterTodos();
        void Deletar(long id);
        void Atualizar(Bebida bebida);
         
    }
}