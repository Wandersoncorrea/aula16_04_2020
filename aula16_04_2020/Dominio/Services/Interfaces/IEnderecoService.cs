using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Services.Interfaces
{
    public interface IEnderecoService
    {
        Endereco Obter(long id);
        IEnumerable<Endereco> ObterTodos();
        Endereco Cadastrar(Endereco endereco);
        Endereco Atualizar(Endereco endereco);
        Endereco Deletar(long id);
    }
}