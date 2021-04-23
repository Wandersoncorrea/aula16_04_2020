using System.Collections.Generic;
using aula16_04_2020.Dominio.DAOs;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.obj.Dominio.DAOs.Interfaces;


namespace aula16_04_2020.Dominio.Repositorios.Classes
{
    public class PizzaRepositorio : IPizzaRepositorio
    {
         private IPizzaDAO pizzaDAO;
        public PizzaRepositorio(IPizzaDAO pizzaDAO)
        {
            this.pizzaDAO = pizzaDAO;
        }
        public void Atualizar(Pizza pizza)
        {
            this.pizzaDAO.Atualizar(pizza);
        }

        public long Cadastrar(Pizza pizza)
        {
            return this.pizzaDAO.Cadastrar(pizza);
        }

        public void Deletar(long id)
        {
            this.pizzaDAO.Deletar(id);
        }

        public Pizza Obter(long id)
        {
            return this.pizzaDAO.Obter(id);
        }

        public IEnumerable<Pizza> ObterTodos()
        {
            return this.pizzaDAO.ObterTodos();
        }
    }
}