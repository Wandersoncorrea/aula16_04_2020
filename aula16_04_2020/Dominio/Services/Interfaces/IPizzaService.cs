using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Services.Interfaces
{
    public interface IPizzaService
    {
        Pizza Obter(long id);
        IEnumerable<Pizza> ObterTodos();
        Pizza Cadastrar(Pizza pizza);
        Pizza Atualizar(Pizza pizza);
        Pizza Deletar(long id);
    }
}