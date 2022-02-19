using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DTOS;
using APP.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InstrutorController : ControllerBase
    {

       private readonly IInstrutorService _instrutorService;
        public InstrutorController(
            IInstrutorService instrutorService
        )
        {
            this._instrutorService = instrutorService;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var instrutor = await _instrutorService.GetAllAsync();
                 if(instrutor == null) return NoContent();

                 return Ok(instrutor);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar instrutores. MSG: {ex.Message}");
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var instrutor = await _instrutorService.GetByIdAsync(id);
                 if(instrutor == null) return NoContent();

                 return Ok(instrutor);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar instrutores. MSG: {ex.Message}");
            }
        }

        [Route("PorNome/{nome}")]
        [HttpGet]
        public async Task<IActionResult> GetPorNome(string nome)
        {
            try
            {
                 var instrutor = await _instrutorService.GetByNomeAsync(nome);
                 if(instrutor == null) return NoContent();

                 return Ok(instrutor);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar instrutores. MSG: {ex.Message}");
            }
        
        }

        /// <summary>
        /// Insere Instrutor
        /// </summary>
        /// <param name="model">DTO de Instrutor</param>
        /// <returns>DTO da Instrutor Inserida</returns>       
        [HttpPost]
        public async Task<IActionResult> Post(InstrutorDto model)
        {
            try
            {
                 var instrutor = await _instrutorService.Add(model);
                 if(instrutor == null) return BadRequest("Erro ao tentar inserir Instrutor.");

                 return Ok(instrutor);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar Instrutores. MSG: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza Instrutor
        /// </summary>
        /// <param name="model">DTO de Instrutor</param>
        /// <returns>DTO Instrutor atualizada</returns>
        [HttpPut]
        public async Task<IActionResult> Put(InstrutorDto model)
        {
            try
            {
                 var instrutor = await _instrutorService.Update(model);
                 if(instrutor == null) return BadRequest("Erro ao tentar atualizar Instrutor.");

                 return Ok(instrutor);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar Instrutor. Erro {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui Instrutor com id Informado
        /// </summary>
        /// <param name="id">ID da Instrutor</param>
        /// <returns>string : Deletado</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var instrutor = await _instrutorService.GetByIdAsync(id);
                if(instrutor == null) return NoContent();

                return await _instrutorService.DeletarOUDesativar(id) 
                    ? Ok(new {message = "Deletado"}) 
                    : throw new Exception("Erro ao tentar excluir o Instrutor.");

            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao excluir o Instrutor. Erro {ex.Message}");
            }
        }

    }
}