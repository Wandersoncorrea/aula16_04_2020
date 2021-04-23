using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aula16_04_2020.Dominio.Models;
using aula16_04_2020;
using Microsoft.AspNetCore.Mvc;
using aula16_04_2020.Dominio.Services.Interfaces;

namespace aula16_04_2020.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]

    public class EnderecoControlle : ControllerBase
    {
        private readonly IEnderecoService _servicoEndereco;

        // public PedidoController(IPedidoService pedidoService) => this._servicoPedido = pedidoService;
        public EnderecoControlle(IEnderecoService enderecoService)
        {
            this._servicoEndereco = enderecoService;
        }
    }
}