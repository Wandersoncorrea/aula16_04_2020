using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.obj.Dominio.DAOs.Interfaces
{
    public interface IPedidoDAO
    {
        long Cadastrar(Pedido pedido);
        Pedido Obter(long id);
        IEnumerable<Pedido> ObterTodos();
        void Deletar(long id);
        void Atualizar(Pedido pedido);
    }
}