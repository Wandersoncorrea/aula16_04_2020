using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.DAOs.Interfaces
{
    public interface IPizzaDAO
    {
        long Cadastrar(Pizza pizza);
        Pizza Obter(long id);
        IEnumerable<Pizza> ObterTodos();
        void Deletar(long id);
        void Atualizar(Pizza pizza);         
    }
}