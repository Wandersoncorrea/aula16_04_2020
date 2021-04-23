using System;
using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.Dominio.Services.Interfaces;

namespace aula16_04_2020.Dominio.Services.Classes
{
    public class PedidoService : IPedidoService
    {
        private IPedidoRepositorio repositorioPedido;
        public PedidoService(IPedidoRepositorio repositorioPedido)
        {
            this.repositorioPedido = repositorioPedido;
        }
        public Pedido Atualizar(Pedido pedido)
        {
            this.repositorioPedido.Atualizar(pedido);

            return pedido;
        }
        public Pedido Cadastrar(Pedido pedido)
        {
           pedido.DataCadastro = DateTime.Now;
          var id = this.repositorioPedido.Cadastrar(pedido);
          
          if(id < 1){
            throw new Exception("Erro em cadastrar pedido.");
          }

          pedido.Id = id;
          return pedido;
        }
        public Pedido Deletar(long id)
        {
            var pedido = this.repositorioPedido.Obter(id);

            if(pedido == null){
                throw new Exception("Não existe Pedido para ser deletado.");
            }

            this.repositorioPedido.Deletar(id);
            
            return pedido;
        }
        public Pedido Obter(long id)
        {
            return this.repositorioPedido.Obter(id);
        }
        public IEnumerable<Pedido> ObterTodos()
        {
           var pedido = this.repositorioPedido.ObterTodos();

            if(pedido == null){
                 throw new Exception("Sem registro de bebidas na base de dados.");
            }
                   
            return pedido;
        }
   
    }
}