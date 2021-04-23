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
    public class ClienteController : ControllerBase
    {

        private readonly IClienteService _servicoCliente;
        public ClienteController(IClienteService servicoCliente)
        {
            this._servicoCliente = servicoCliente;
        }
        
        // GET api/cliente/5
        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(long id)
        {
            
            if(id < 1){
                return BadRequest(new {
                    mensagem = "Não foi possível obter o cliente pelo id:" + id
                });
            }

            try
            {   
                return _servicoCliente.Obter(id);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
 
        // POST api/cliente
        [HttpPost]
        public ActionResult<Object> Post([FromBody] Cliente cliente)
        {
            // Logar a requisicão, saber quem enviou, oque e quando.
            // Posso validar de forma simples o objeto.
            // Servico de cliente e mandar gravar essa nota.
            // Com o retorno do meu servico, eu devolvo ao usuario.

            if(!cliente.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "Informacões obrigatórias incompletas."
                });
            }
            
            try
            {   
                return _servicoCliente.Cadastrar(cliente);
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
        public ActionResult<Object> Put([FromBody] Cliente cliente, long id)
        {
             if(!cliente.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "As informacões obrigatórias não foram informadas."
                });
            }
            
            try
            {  
                cliente.Id = id;
                return _servicoCliente.Atualizar(cliente);
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
        public ActionResult<Cliente> Delete(long id)
        {
            if(id < 1){
                return BadRequest(new {
                    mensagem = "Não foi possível obter o cliente pelo id:" + id
                });
            } 

            try
            {   
                return _servicoCliente.Deletar(id);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
   
       [HttpGet]
        public ActionResult<IEnumerable< Cliente>> Get()
        {
            //conversão implicita to na duvida se ta certo.
            Cliente[] clientes = new Cliente[]{};
            clientes = (Cliente[])_servicoCliente.ObterTodos();
            
            if(clientes == null){
                return BadRequest(new {
                    mensagem = "Não foi possível obter a lista clientes."
                });
            }

            try
            {   
                return clientes;
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
 
  // [HttpGet]
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }
    }

}//namespace fim
