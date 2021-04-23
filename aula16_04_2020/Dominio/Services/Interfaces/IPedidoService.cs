using System.Collections.Generic;
using aula16_04_2020.Dominio.Models;

namespace aula16_04_2020.Dominio.Services.Interfaces
{
    public interface IPedidoService
    {
        Pedido Obter(long id);
        IEnumerable<Pedido> ObterTodos();
        Pedido Cadastrar(Pedido pedido);
        Pedido Atualizar(Pedido pedido);
        Pedido Deletar(long id); 
    }
}