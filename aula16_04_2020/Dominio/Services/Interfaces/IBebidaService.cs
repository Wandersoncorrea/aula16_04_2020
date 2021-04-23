using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Services.Interfaces
{
    public interface IBebidaService
    {
         Bebida Obter(long id);
        IEnumerable<Bebida> ObterTodos();
        Bebida Cadastrar(Bebida bebida);
        Bebida Atualizar(Bebida bebida);
        Bebida Deletar(long id);
    }
}