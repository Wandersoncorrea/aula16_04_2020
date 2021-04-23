using System.Data.SqlClient;
//using Dapper;
using aula16_04_2020.Dominio.Models;
using System.Linq;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using System.Collections.Generic;

namespace aula16_04_2020.Dominio.DAOs
{
    public class PizzaDAO : IPizzaDAO
    {
        private string connectionString;

        public PizzaDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Atualizar(Pizza pizza)
        {
            var sql = @"UPDATE pizza
                        SET descricao = @Descricao,
                            tamanho = @Tamanho,
                            ingredientes = @Ingredientes,
                            valor = @Valor,
                            dataCadastro = @DataCadastro
                        WHERE id = @Id";


            using(var conexao = new SqlConnection(this.connectionString))
            {
               conexao.Execute(sql, pizza);
            }
        }

        public long Cadastrar(Pizza pizza)
        {
             using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<long>(@"INSERT INTO cliente 
                                        (descricao, tamanho,ingredientes,valor, dataCadastro) 
                                      VALUES
                                      (@Decricao,@Tamanho,@Ingredientes, @Valor, @DataCadastro);
                                      SELECT SCOPE_IDENTITY()",
                                      pizza ).FirstOrDefault();
            }
        }

        public void Deletar(long id)
        {
             using(var conexao = new SqlConnection(this.connectionString))
            {
                conexao.Execute(@"DELETE FROM pizza 
                                WHERE id = @Id", new { @Id = id } );
            }
        }

        public Pizza Obter(long id)
        {
             using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<Cliente>(@"SELECT * 
                                              FROM pizza 
                                              WHERE id = @Id", new { @Id = id } ).FirstOrDefault();
            }
        }

        public IEnumerable<Pizza> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}