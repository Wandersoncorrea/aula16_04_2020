using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Services.Interfaces
{
    public interface IClienteService
    {
        Cliente Obter(long id);
        IEnumerable<Cliente> ObterTodos();
        Cliente Cadastrar(Cliente cliente);
        Cliente Atualizar(Cliente cliente);
        Cliente Deletar(long id);

    }
}