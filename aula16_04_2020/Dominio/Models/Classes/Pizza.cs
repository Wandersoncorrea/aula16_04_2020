using System;
using System.Collections.Generic;
using System.Linq;
using aula16_04_2020.Dominio;
using aula16_04_2020.Dominio.Interfaces;


namespace aula16_04_2020.Dominio.Models
{
    public class Pizza
    {
        //Pizza: descricao, tamanho, ingredientes, valor
        public long Id {get; set;}
        public string Descricao{get;set;}
        public String Tamanho{get;set;}
        public String Ingredientes{get;set;}
        public double Valor{get;set;}
        public int Quantidade {get;set;}
        public DateTime DataCadastro {get;set;}

        public bool ValidoParaCadastro()
        {
             return (this.Valor != 0 && 
                    !String.IsNullOrWhiteSpace(this.Descricao) &&
                    !String.IsNullOrWhiteSpace(this.Tamanho));
        }

        public double CalcularValor()
        {
            return (this.Valor * this.Quantidade);
        }
    }
}