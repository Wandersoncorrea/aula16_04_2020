using System.Collections.Generic;
using aula16_04_2020.Dominio.DAOs;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.obj.Dominio.DAOs.Interfaces;

namespace aula16_04_2020.Dominio.Repositorios
{
    public class PedidoRepositorio : IPedidoRepositorio
    {
        private IPedidoDAO pedidoDAO;
        public PedidoRepositorio(IPedidoDAO pedidoDAO)
        {
            this.pedidoDAO = pedidoDAO;
        }

        public void Atualizar(Pedido pedido)
        {
            this.pedidoDAO.Atualizar(pedido); 
        }

        public long Cadastrar(Pedido pedido)
        {
           return this.pedidoDAO.Cadastrar(pedido);
        }

        public void Deletar(long id)
        {
            this.pedidoDAO.Deletar(id);
        }

        public Pedido Obter(long id)
        {
            return this.pedidoDAO.Obter(id);
        }

        public IEnumerable<Pedido> ObterTodos()
        {
            return this.pedidoDAO.ObterTodos();
        }
    }
}
