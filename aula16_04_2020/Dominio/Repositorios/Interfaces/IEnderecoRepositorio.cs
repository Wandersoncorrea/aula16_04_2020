using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;


namespace aula16_04_2020.Dominio.Repositorios.Interfaces
{
    public interface IEnderecoRepositorio
    {
        Endereco Obter(long id);
        long Cadastrar(Endereco endereco);
        
        IEnumerable<Endereco> ObterTodos();
        void Atualizar(Endereco endereco);
        void Deletar(long id);
    }
}