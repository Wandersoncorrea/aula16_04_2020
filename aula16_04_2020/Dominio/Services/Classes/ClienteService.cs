using System;
using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.Dominio.Services.Interfaces;

namespace aula16_04_2020.Dominio.Services
{   
    public class ClienteService : IClienteService
    {
        private IClienteRepositorio repositorioCliente;
         public ClienteService(IClienteRepositorio repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }

        public Cliente Obter(long id)
        {
            return this.repositorioCliente.Obter(id);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            IEnumerable<Cliente> clientes = this.repositorioCliente.ObterTodos();

             if(clientes== null){
                throw new Exception("Sem registro de clientes na base de dados.");
            }

            return clientes;
            
            //return new List<Cliente>();
        }

        public Cliente Cadastrar(Cliente cliente)
        {
          cliente.DataCadastro = DateTime.Now;
          var id = this.repositorioCliente.Cadastrar(cliente);
          
          if(id < 1){
            throw new Exception("Não foi possível cadastrar o cliente.");
          }

          cliente.Id = id;
          return cliente;
        }

        
        public Cliente Atualizar(Cliente cliente)
        {
            this.repositorioCliente.Atualizar(cliente);

            return cliente;
        }

        
        public Cliente Deletar(long id)
        {
            // Aqui vai ter a logica para obte ro cliente por id.
            var cliente = this.repositorioCliente.Obter(id);

            if(cliente == null){
                throw new Exception("Não existe cliente para ser deletado.");
            }

            this.repositorioCliente.Deletar(id);
            
            return cliente;
        }

    }
}