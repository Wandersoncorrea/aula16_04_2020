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
    public class BebidaController: ControllerBase
    {
         private readonly IBebidaService _servicoBebida;

        // public PedidoController(IPedidoService pedidoService) => this._servicoPedido = pedidoService;
        public BebidaController( IBebidaService bebidaService)
        {
            this._servicoBebida = bebidaService;
        }
        
         // GET api/Bebida/5
        [HttpGet("{id}")]
        public ActionResult<Bebida> Get(long id)
        {
            
            if(id < 1){
              return BadRequest(new {
                mensagem = "Não foi possível obter a bebida pelo id:" + id});
            }
            try
            {   
              return _servicoBebida.Obter(id);
            }
            catch (System.Exception ex)
            {
              return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
 
         // POST api/Bebida
        [HttpPost]
        public ActionResult<Object> Post([FromBody] Bebida bebida)
        {
            // Logar a requisicão, saber quem enviou, oque e quando.
            // Posso validar de forma simples o objeto.
            // Servico de Bebida e mandar gravar essa nota.
            // Com o retorno do meu servico, eu devolvo ao usuario.

            if(!bebida.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "Informacões obrigatórias incompletas."
                });
            }            
            try
            {   
                return _servicoBebida.Cadastrar(bebida);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Object> Put([FromBody] Bebida bebida, long id)
        {
             if(!bebida.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "As informacões obrigatórias não foram informadas."
                });
            }            
            try
            {  
                bebida.Id = id;
                return _servicoBebida.Atualizar(bebida);
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
        public ActionResult<Bebida> Delete(long id)
        {
            if(id < 1){
                return BadRequest(new {
                    mensagem = "Não foi possível obter o Bebida pelo id:" + id
                });
            } 

            try
            {   
                return _servicoBebida.Deletar(id);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
   
       [HttpGet]
        public ActionResult<IEnumerable< Bebida>> Get()
        {
            //conversão implicita to na duvida se ta certo.
            Bebida[] bebidas = new Bebida[]{};
            bebidas = (Bebida[])_servicoBebida.ObterTodos();
            
            if(bebidas == null){
                return BadRequest(new {
                    mensagem = "Não foi possível obter a lista bebidas."
                });
            }

            try
            {   
                return bebidas;
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }

        
    }//fim da classe
}