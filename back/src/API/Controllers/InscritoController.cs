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
    public class InscritoController : ControllerBase
    {

       private readonly IInscritoService _inscritoService;
        public InscritoController(
            IInscritoService inscritoService
        )
        {
            this._inscritoService = inscritoService;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var Inscrito = await _inscritoService.GetAllAsync();
                 if(Inscrito == null) return NoContent();

                 return Ok(Inscrito);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Inscritoes. MSG: {ex.Message}");
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var Inscrito = await _inscritoService.GetByIdAsync(id);
                 if(Inscrito == null) return NoContent();

                 return Ok(Inscrito);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Inscritoes. MSG: {ex.Message}");
            }
        }

        [Route("PorNome/{nome}")]
        [HttpGet]
        public async Task<IActionResult> GetPorNome(string nome)
        {
            try
            {
                 var Inscrito = await _inscritoService.GetByNomeAsync(nome);
                 if(Inscrito == null) return NoContent();

                 return Ok(Inscrito);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Inscritoes. MSG: {ex.Message}");
            }
        
        }

        /// <summary>
        /// Insere Inscrito
        /// </summary>
        /// <param name="model">DTO de Inscrito</param>
        /// <returns>DTO da Inscrito Inserida</returns>       
        [HttpPost]
        public async Task<IActionResult> Post(InscritoDto model)
        {
            try
            {
                 var Inscrito = await _inscritoService.Add(model);
                 if(Inscrito == null) return BadRequest("Erro ao tentar inserir Inscrito.");

                 return Ok(Inscrito);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar Inscritoes. MSG: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza Inscrito
        /// </summary>
        /// <param name="model">DTO de Inscrito</param>
        /// <returns>DTO Inscrito atualizada</returns>
        [HttpPut]
        public async Task<IActionResult> Put(InscritoDto model)
        {
            try
            {
                 var Inscrito = await _inscritoService.Update(model);
                 if(Inscrito == null) return BadRequest("Erro ao tentar atualizar Inscrito.");

                 return Ok(Inscrito);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar Inscrito. Erro {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui Inscrito com id Informado
        /// </summary>
        /// <param name="id">ID da Inscrito</param>
        /// <returns>string : Deletado</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Inscrito = await _inscritoService.GetByIdAsync(id);
                if(Inscrito == null) return NoContent();

                return await _inscritoService.DeletarOUDesativar(id) 
                    ? Ok(new {message = "Deletado"}) 
                    : throw new Exception("Erro ao tentar excluir o Inscrito.");

            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao excluir o Inscrito. Erro {ex.Message}");
            }
        }

    }
}