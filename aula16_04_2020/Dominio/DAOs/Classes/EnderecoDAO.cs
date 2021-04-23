using System.Data.SqlClient;
//using Dapper;
using aula16_04_2020.Dominio.Models;
using System.Linq;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using System.Collections.Generic;

namespace aula16_04_2020.Dominio.DAOs
{
    public class EnderecoDAO : IEnderecoDAO
    {
         private string connectionString;
         public EnderecoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Atualizar(Endereco endereco)
        {
                       var sql = @"UPDATE endereco
                        SET cep = @Cep,
                            rua   = @rua,
                            numero = @Numero,
                            bairro = @Bairro,
                            cidade = @Cidade,
                            complemento  = @Complemento, 
                            pontoreferencia    = @PontoReferencia
                            
                        WHERE id = @Id";


            using(var conexao = new SqlConnection(this.connectionString))
            {
               conexao.Execute(sql, endereco);
            }
        }

        public long Cadastrar(Endereco endereco)
        {
              using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<long>(@"INSERT INTO endereco 
                                        (cep,rua,numero,bairro,cidade,complemento,pontoreferencia) 
                                      VALUES
                                      (@Cep,@Rua,@Numero,@Bairro,@Cidade,@Complemento,@Pontoreferencia,);
                                      SELECT SCOPE_IDENTITY()",
                                      endereco ).FirstOrDefault();
            }
        }

        public void Deletar(long id)
        {
              using(var conexao = new SqlConnection(this.connectionString))
            {
                conexao.Execute(@"DELETE FROM endereco  
                                WHERE id = @Id", new { @Id = id } );
            }
        }

        public Endereco Obter(long id)
        {
            using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<Cliente>(@"SELECT * 
                                              FROM endereco
                                              WHERE id = @Id", new { @Id = id } ).FirstOrDefault();
            }
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
    
    }