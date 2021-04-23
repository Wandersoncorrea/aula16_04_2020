using System.Collections.Generic;
using aula16_04_2020.Dominio.DAOs;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.obj.Dominio.DAOs.Interfaces;

namespace aula16_04_2020.Dominio.Repositorios.Classes
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private IEnderecoDAO enderecoDAO;
        public EnderecoRepositorio(IEnderecoDAO enderecoDAO)
        {
            this.enderecoDAO = enderecoDAO;
        }


        public void Atualizar(Endereco endereco)
        {
           this.enderecoDAO.Atualizar(endereco);
        }

        public long Cadastrar(Endereco endereco)
        {
            return this.enderecoDAO.Cadastrar(endereco);
        }

        public void Deletar(long id)
        {
            this.enderecoDAO.Deletar(id);
        }

        public Endereco Obter(long id)
        {
            return this.enderecoDAO.Obter(id);
        }

        public IEnumerable<Endereco> ObterTodos()
        {
            return this.enderecoDAO.ObterTodos();
        }
    }
}