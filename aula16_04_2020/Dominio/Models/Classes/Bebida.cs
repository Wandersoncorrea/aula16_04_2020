using System;
using System.Collections.Generic;
using System.Linq;
using aula16_04_2020.Dominio.Interfaces;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Models.Interfaces;

namespace aula16_04_2020.Dominio.Models
{
public class Bebida : IBebida
{

    //Bebida: descricao, tamanho,  valor
    public long Id {get; set;}
    public string Descricao{get;set;}
    public string Tamanho{get;set;}
    public double Valor{get;set;}
    public int Quantidade {get;set;}
    public DateTime DataCadastro {get;set;}

         public bool ValidoParaCadastro()
        {
         return (this.Valor != 0 && 
                    !String.IsNullOrWhiteSpace(this.Descricao) &&
                    !String.IsNullOrWhiteSpace(this.Tamanho));
        }

        public double CalcularTotal()
        {
           return (this.Valor * this.Quantidade);
        }
    }

}