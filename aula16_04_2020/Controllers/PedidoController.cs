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
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _servicoPedido;

        // public PedidoController(IPedidoService pedidoService) => this._servicoPedido = pedidoService;
        public PedidoController( IPedidoService pedidoService)
        {
            this._servicoPedido = pedidoService;
        }

        // [HttpGet] 
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        [HttpGet("{id}")]
        public ActionResult<Pedido> Get(long id)
        {
            
            if(id < 1){
                return BadRequest(new {
                    mensagem = "Não foi possível obter a pedido pelo id:" + id
                });
            }

            try
            {   
                return _servicoPedido.Obter(id);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
 
        [HttpPost]
        public ActionResult<Object> Post([FromBody] Pedido pedido)
        {
            if(!pedido.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "Informacões obrigatórias incompletas."
                });
            }
            
            try
            {   
                return _servicoPedido.Cadastrar(pedido);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
            

          
            // return BadRequest();
            // return Ok();
            // return NotFound();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Object> Put([FromBody] Pedido pedido, long id)
        {
             if(!pedido.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "As informacões obrigatórias não foram informadas."
                });
            }
            
            try
            {  
               pedido.Id = id;
                return _servicoPedido.Atualizar(pedido);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<Pedido> Delete(long id)
        {
            if(id < 1){
                return BadRequest(new {
                    mensagem = "Não foi possível obter o Pedido pelo id:" + id
                });
            } 

            try
            {   
                return _servicoPedido.Deletar(id);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
    
       [HttpGet]
        public ActionResult<IEnumerable<Pedido>> Get()
        {
            //conversão implicita to na duvida se ta certo.
            Pedido[] pedidos = new Pedido[]{};
            pedidos = (Pedido[])_servicoPedido.ObterTodos();
            
            if(pedidos == null){
                return BadRequest(new {
                    mensagem = "Não foi possível obter a lista de Pedidos."
                });
            }

            try
            {   
                return pedidos;
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }

    }

}