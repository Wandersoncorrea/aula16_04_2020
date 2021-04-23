using System.Collections.Generic;
using aula16_04_2020.Dominio.DAOs;
using aula16_04_2020.Dominio.DAOs.Interfaces;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020.Dominio.Repositorios.Interfaces;
using aula16_04_2020.obj.Dominio.DAOs.Interfaces;

namespace aula16_04_2020.Dominio.Repositorios.Classes
{
    public class BebidaRepositorio : IBebidaRepositorio
    {
        private IBebidaDAO bebidaDAO;
        public BebidaRepositorio(IBebidaDAO bebidaDAO)
        {
            this.bebidaDAO = bebidaDAO;
        }
        public void Atualizar(Bebida bebida)
        {
            this.bebidaDAO.Atualizar(bebida);
        }

        public long Cadastrar(Bebida bebida)
        {
           return this.bebidaDAO.Cadastrar(bebida);
        }

        public void Deletar(long id)
        {
            this.bebidaDAO.Deletar(id);
        }

        public Bebida Obter(long id)
        {
           return this.Obter(id);
        }

        public IEnumerable<Bebida> ObterTodos()
        {
            return this.bebidaDAO.ObterTodos();
        }
    }
}