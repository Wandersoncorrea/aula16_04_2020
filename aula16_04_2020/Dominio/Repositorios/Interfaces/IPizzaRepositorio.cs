using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Repositorios.Interfaces
{
    public interface IPizzaRepositorio
    {
         
        Pizza Obter(long id);
        long Cadastrar(Pizza pizza);
        
        IEnumerable<Pizza> ObterTodos();
        void Atualizar(Pizza pizza);
        void Deletar(long id);
        
    }
}