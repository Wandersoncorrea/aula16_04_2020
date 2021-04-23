using System;
using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.Dominio.Services.Interfaces;

namespace aula16_04_2020.Dominio.Services.Classes
{
    public class EnderecoService : IEnderecoService
    {
         private IEnderecoRepositorio repositorioEndereco;
         public EnderecoService(IEnderecoRepositorio repositorioEndereco)
        {
            this.repositorioEndereco = repositorioEndereco;
        }
        public Endereco Atualizar(Endereco endereco)
        {
           this.repositorioEndereco.Atualizar(endereco);

            return endereco;
        }

        public Endereco Cadastrar(Endereco endereco)
        {
            var id = this.repositorioEndereco.Cadastrar(endereco);
          
          if(id < 1){
            throw new Exception("Não foi possível cadastrar o endereço.");
          }

          endereco.Id = id;
          return endereco;
        }

        public Endereco Deletar(long id)
        {
           var endereco = this.repositorioEndereco.Obter(id);

            if(endereco == null){
                throw new Exception("Não existe cliente para ser deletado.");
            }

            this.repositorioEndereco.Deletar(id);
            
            return endereco;
        }

        public Endereco Obter(long id)
        {
            return this.repositorioEndereco.Obter(id);
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            IEnumerable<Endereco> enderecos = this.repositorioEndereco.ObterTodos();

             if(enderecos== null){
                throw new Exception("Sem registro de enderecos na base de dados.");
            }

            return enderecos;
        }
    }
}