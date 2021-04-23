using System.Data.SqlClient;
//using Dapper;
using aula16_04_2020.Dominio.Models;
using System.Linq;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using aula16_04_2020.obj.Dominio.DAOs.Interfaces;
using System.Collections.Generic;

namespace aula16_04_2020.Dominio.DAOs
{
    public class PedidoDAO : IPedidoDAO
    {
        private string connectionString;

        public PedidoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Atualizar(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }

        public long Cadastrar(Pedido pedido)
        {
            throw new System.NotImplementedException();
        }

        public void Deletar(long id)
        {
            throw new System.NotImplementedException();
        }

        public Pedido Obter(long id)
        {
            throw new System.NotImplementedException();
        }
         public IEnumerable<Pedido> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}