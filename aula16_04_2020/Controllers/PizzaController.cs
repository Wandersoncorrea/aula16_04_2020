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
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _servicoPizza;
       // public PizzaController(IPizzaService pizzaService) => this._servicoPizza = pizzaService;
       public PizzaController(IPizzaService pizzaService)
        {
            this._servicoPizza = pizzaService;
        }

        // [HttpGet] 
        // public ActionResult<IEnumerable<string>> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(long id)
        {
            
            if(id < 1){
                return BadRequest(new {
                    mensagem = "Não foi possível obter a pizza pelo id:" + id
                });
            }

            try
            {   
                return _servicoPizza.Obter(id);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
 
        [HttpPost]
        public ActionResult<Object> Post([FromBody] Pizza pizza)
        {
            if(!pizza.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "Informacões obrigatórias incompletas."
                });
            }
            
            try
            {   
                return _servicoPizza.Cadastrar(pizza);
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
        public ActionResult<Object> Put([FromBody] Pizza pizza, long id)
        {
             if(!pizza.ValidoParaCadastro()){
                return BadRequest(new {
                    mensagem = "As informacões obrigatórias não foram informadas."
                });
            }
            
            try
            {  
               pizza.Id = id;
                return _servicoPizza.Atualizar(pizza);
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
        public ActionResult<Pizza> Delete(long id)
        {
            if(id < 1){
                return BadRequest(new {
                    mensagem = "Não foi possível obter o Pizza pelo id:" + id
                });
            } 

            try
            {   
                return _servicoPizza.Deletar(id);
            }
            catch (System.Exception ex)
            {
               return BadRequest(new {
                   mensagem = ex.Message
               });
            }
        }
    
       [HttpGet]
        public ActionResult<IEnumerable<Pizza>> Get()
        {
            //conversão implicita to na duvida se ta certo.
            Pizza[] pizzas = new Pizza[]{};
            pizzas = (Pizza[])_servicoPizza.ObterTodos();
            
            if(pizzas == null){
                return BadRequest(new {
                    mensagem = "Não foi possível obter a lista de Pizzas."
                });
            }

            try
            {   
                return pizzas;
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