using System;
using System.Collections.Generic;
using System.Linq;
using aula16_04_2020.Dominio;
using aula16_04_2020.Dominio.Interfaces;



namespace aula16_04_2020.Dominio.Models
{
    public class Pedido : IPedido
    {
        
        //Pedido: descricao, numero, 
        //Lista de Pizzas, Lista de bebidas, 
        //desconto, frete, valor total do pedido.
        public long Id {get; set;}
        public Cliente Cliente { get; set; }
        public long Numero{get;set;}
        public string Descricao{get;set;}//????
        public List<Pizza> Pizzas  { get; set; }
        public List<Bebida> Bebidas  { get; set; }
        public double Desconto { get; set; } 
        public double Frete { get; set; } 
        public double ValorToTal { get; private set;}
        public DateTime DataCadastro {get;set;}
        
        public bool ValidoParaCadastro()
        {
            return (this.Pizzas.Any() && this.Cliente.Id != 0);
        }

        public void CalcularValorTotal()
        {
            double valorTotalProdutos = 0;
            double valorTotalImpostos = 0;

            this.Pizzas.ForEach(produto => {
                valorTotalProdutos += produto.CalcularValor();
            });

            this.ValorToTal = (valorTotalProdutos + 
                                     this.Frete - 
                                     this.Desconto) + valorTotalImpostos;

        }

        public double CalcularTotal()
        {
            throw new NotImplementedException();
        }
    }

}