using System;
using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.Dominio.Services.Interfaces;

namespace aula16_04_2020.Dominio.Services.Classes
{
    public class PizzaService : IPizzaService
    {
        private IPizzaRepositorio repositorioPizza; 
        public PizzaService(IPizzaRepositorio repositorioPizza)
        {
            this.repositorioPizza = repositorioPizza;
        }
        public Pizza Atualizar(Pizza pizza)
        {
            this.repositorioPizza.Atualizar(pizza);
            return pizza;
        }

        public Pizza Cadastrar(Pizza pizza)
        {
          pizza.DataCadastro = DateTime.Now;
          var id = this.repositorioPizza.Cadastrar(pizza);
          
          if(id < 1){
            throw new Exception("Erro ao cadastrar a pizza.");
          }

          pizza.Id = id;
          return pizza;
        }

        public Pizza Deletar(long id)
        {
            var pizza = this.repositorioPizza.Obter(id);
            if(pizza == null)
            {
                throw new Exception("Nao exiter pizza a se deletada");
            }
               
            this.repositorioPizza.Deletar(id);
            return pizza;

        }

        public Pizza Obter(long id)
        {
            return this.repositorioPizza.Obter(id);
        }

        public IEnumerable<Pizza> ObterTodos()
        {
           IEnumerable<Pizza> pizzas = this.repositorioPizza.ObterTodos();
           if(pizzas == null)
           {
               throw new Exception("Não exitem pizzas na base de dados");
           }
           return pizzas;
        }
    }
}