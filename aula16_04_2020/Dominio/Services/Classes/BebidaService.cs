using System;
using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.Dominio.Services.Interfaces;

namespace aula16_04_2020.Dominio.Services.Classes
{
    public class BebidaService : IBebidaService
    {
        private IBebidaRepositorio repositorioBebida;
         public BebidaService(IBebidaRepositorio repositorioBebida)
        {
            this.repositorioBebida = repositorioBebida;
        }
        public Bebida Atualizar(Bebida bebida)
        {
            this.repositorioBebida.Atualizar(bebida);
            return bebida;

        }

        public Bebida Cadastrar(Bebida bebida)
        {
          bebida.DataCadastro = DateTime.Now;
          var id = this.repositorioBebida.Cadastrar(bebida);
          
          if(id < 1){
            throw new Exception("Erro ao cadastrar a bebida.");
          }

          bebida.Id = id;
          return bebida;
        }

        public Bebida Deletar(long id)
        {
            var bebida = this.repositorioBebida.Obter(id);

            if(bebida == null){
                throw new Exception("Não existe bebida para ser deletado.");
            }

            this.repositorioBebida.Deletar(id);
            
            return bebida;
        }
        public Bebida Obter(long id)
        {
            return this.repositorioBebida.Obter(id);
        }

        public IEnumerable<Bebida> ObterTodos()
        {
             IEnumerable<Bebida> bebidas = this.repositorioBebida.ObterTodos();

             if(bebidas == null){
                throw new Exception("Sem registro de bebidas na base de dados.");
            }

            return bebidas;

        }
    
    }
}