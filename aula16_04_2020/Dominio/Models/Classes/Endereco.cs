using System;
using aula16_04_2020.Dominio.Models.Interfaces;

namespace aula16_04_2020.Dominio.Models
{
    public class Endereco : IEndereco
    {
       public long Id {get; set;}
       public string Cidade{get; set;}
       public string Bairro{get; set;}
       public string Rua{get; set;}
       public string Numero{get; set;}
       public string Cep{get; set;}

       public string Complemento{get;set;} 
       public string PontoReferencia{get;set;}
       public DateTime DataCadastro {get;set;}

        
        public bool ValidoParaCadastro()
        {
             return (!String.IsNullOrWhiteSpace(this.Cep) && 
                     !String.IsNullOrWhiteSpace(this.Bairro) &&
                     !String.IsNullOrWhiteSpace(this.Rua));
        }
    }
}