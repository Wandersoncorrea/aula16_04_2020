using System;
using System.Collections.Generic;
using System.Linq;
using aula16_04_2020.Dominio.Interfaces;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Models.Interfaces;

namespace aula16_04_2020.Dominio.Models
{
    public class Cliente : ICliente
    {
        public long Id {get; set;}
        public string Nome {get; set;}
        public string Telefone {get;set;}
        public long CPF {get; set;}
        public long Id_endereco{get;set;}
        
        /// <summary>
        /// Data de Cadastro do cliente. É preenchida automaticamente.
        /// </summary>
        public DateTime DataCadastro {get;set;}


        /// <summary>
        /// Metodo para validar se um cliente esta com as informacões devidamente preenchidas para seu cadastro.
        /// Informacões obrigatórias:
        /// CPF, Nome e telefone
        /// </summary>
        /// <returns> Retorna 'True' ou 'False' de acordo com a validacão.</returns>
        public bool ValidoParaCadastro()
        {
            return (this.CPF != 0 && 
                    !String.IsNullOrWhiteSpace(this.Nome) &&
                    !String.IsNullOrWhiteSpace(this.Telefone));
        }
    }
}