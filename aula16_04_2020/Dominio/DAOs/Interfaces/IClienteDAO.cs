using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.DAOs.Interfaces
{
    public interface IClienteDAO
    {
        long Cadastrar(Cliente cliente);
        Cliente Obter(long id);
        IEnumerable<Cliente> ObterTodos();
        void Deletar(long id);
        void Atualizar(Cliente cliente);
         
    }
}