using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Repositorios.Interfaces
{
    public interface IClienteRepositorio
    {
        Cliente Obter(long id);
        long Cadastrar(Cliente cliente);
       
        IEnumerable<Cliente> ObterTodos();
        void Atualizar(Cliente cliente);
        void Deletar(long id);
        
         
    }
}