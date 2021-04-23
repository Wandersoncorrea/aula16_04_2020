using System.Data.SqlClient;
//using Dapper;
using aula16_04_2020.Dominio.Models;
using System.Linq;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using System.Collections.Generic;

namespace aula16_04_2020.Dominio.DAOs
{
    public class ClienteDAO: IClienteDAO
    {
        private string connectionString;

        public ClienteDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public long Cadastrar(Cliente cliente)
        {
            using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<long>(@"INSERT INTO cliente 
                                        (nome, celular,cpf,Id_endereco, dataCadastro) 
                                      VALUES
                                      (@Nome,@Celular, @CPF,@id_endereco, @DataCadastro);
                                      SELECT SCOPE_IDENTITY()",
                                      cliente ).FirstOrDefault();
            }
        }

        public Cliente Obter(long id)
        {
            using(var conexao = new SqlConnection(this.connectionString))
            {
               return conexao.Query<Cliente>(@"SELECT * 
                                              FROM cliente 
                                              WHERE id = @Id", new { @Id = id } ).FirstOrDefault();
            }
        }

        public void Deletar(long id)
        {
            using(var conexao = new SqlConnection(this.connectionString))
            {
                conexao.Execute(@"DELETE FROM Cliente 
                                WHERE id = @Id", new { @Id = id } );
            }
        }

        public void Atualizar(Cliente cliente)
        {
            var sql = @"UPDATE cliente
                        SET nome = @Nome,
                            celular= @Telefone,
                            cpf= @CPF,
                            id_endereco = @id_endereco,
                            dataCadastro = @DataCadastro
                        WHERE id = @Id";


            using(var conexao = new SqlConnection(this.connectionString))
            {
               conexao.Execute(sql, cliente);
            }
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}