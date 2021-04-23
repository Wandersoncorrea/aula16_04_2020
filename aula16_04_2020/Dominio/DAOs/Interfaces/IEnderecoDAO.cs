using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.DAOs.Interfaces
{
    public interface IEnderecoDAO
    {
        long Cadastrar(Endereco endereco);
        Endereco Obter(long id);
        IEnumerable<Endereco> ObterTodos();
        void Deletar(long id);
        void Atualizar(Endereco endereco);
         
    }
}