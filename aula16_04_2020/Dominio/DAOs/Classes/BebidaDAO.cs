using System.Data.SqlClient;
//using Dapper;
using aula16_04_2020.Dominio.Models;
using System.Linq;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using aula16_04_2020.obj.Dominio.DAOs.Interfaces;
using System.Collections.Generic;

namespace aula16_04_2020.Dominio.DAOs
{
    public class BebidaDAO : IBebidaDAO
    {
        private string connectionString;

        public BebidaDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public long Cadastrar(Bebida bebida)
        {
             using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<long>(@"INSERT INTO cliente 
                                        (descricao, tamanho,valor, dataCadastro) 
                                      VALUES
                                      (@Decricao,@Tamanho, @Valor, @DataCadastro);
                                      SELECT SCOPE_IDENTITY()",
                                      bebida ).FirstOrDefault();
            }
        }

        public void Atualizar(Bebida bebida)
        {
          var sql = @"UPDATE bebida
                        SET descricao = @Descricao,
                            tamanho = @Tamanho,
                            valor = @Valor,
                            dataCadastro = @DataCadastro
                        WHERE id = @Id";


            using(var conexao = new SqlConnection(this.connectionString))
            {
               conexao.Execute(sql, bebida);
            }
        }

        public void Deletar(long id)
        {
             using(var conexao = new SqlConnection(this.connectionString))
            {
                conexao.Execute(@"DELETE FROM bebida 
                                WHERE id = @Id", new { @Id = id } );
            }
        }

        public Bebida Obter(long id)
        {
             using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<Cliente>(@"SELECT * 
                                              FROM bebida 
                                              WHERE id = @Id", new { @Id = id } ).FirstOrDefault();
            }
        }

        public IEnumerable<Bebida> ObterTodos()
        {
            using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<Cliente[]>(@"SELECT * 
                                              FROM bebida"
                                              );
            }
        }
    }

    
}