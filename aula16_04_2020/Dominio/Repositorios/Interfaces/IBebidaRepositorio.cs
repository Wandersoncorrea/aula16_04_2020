using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Repositorios.Interfaces
{
    public interface IBebidaRepositorio
    {
        Bebida Obter(long id);
        long Cadastrar(Bebida bebida);
       
        IEnumerable<Bebida> ObterTodos();
        void Atualizar(Bebida bebida);
        void Deletar(long id);
    }
}