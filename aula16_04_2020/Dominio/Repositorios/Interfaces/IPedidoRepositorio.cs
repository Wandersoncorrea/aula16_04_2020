using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Repositorios.Interfaces
{
    public interface IPedidoRepositorio
    {
         Pedido Obter(long id);
        long Cadastrar(Pedido pedido);
        
        IEnumerable<Pedido> ObterTodos();
        void Atualizar(Pedido pedido);
        void Deletar(long id);
    }
}