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
    public class InscricaoController : ControllerBase
    {

       private readonly IInscricaoService _InscricaoService;
        public InscricaoController(
            IInscricaoService InscricaoService
        )
        {
            this._InscricaoService = InscricaoService;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var Inscricao = await _InscricaoService.GetAllAsync();
                 if(Inscricao == null) return NoContent();

                 return Ok(Inscricao);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Inscricaoes. MSG: {ex.Message}");
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var Inscricao = await _InscricaoService.GetByIdAsync(id);
                 if(Inscricao == null) return NoContent();

                 return Ok(Inscricao);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Inscricaoes. MSG: {ex.Message}");
            }
        }

        [Route("PorInscrito/{inscritoId}")]
        [HttpGet]
        public async Task<IActionResult> GetByInscrito(int inscritoId)
        {
            try
            {
                 var Inscricao = await _InscricaoService.GetByInscritoAsync(inscritoId);
                 if(Inscricao == null) return NoContent();

                 return Ok(Inscricao);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Inscricaoes. MSG: {ex.Message}");
            }
        
        }

        [Route("PorLive/{liveId}")]
        [HttpGet]
        public async Task<IActionResult> GetByLive(int liveId)
        {
            try
            {
                 var Inscricao = await _InscricaoService.GetByLiveAsync(liveId);
                 if(Inscricao == null) return NoContent();

                 return Ok(Inscricao);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Inscricaoes. MSG: {ex.Message}");
            }
        
        }

        /// <summary>
        /// Insere Inscricao
        /// </summary>
        /// <param name="model">DTO de Inscricao</param>
        /// <returns>DTO da Inscricao Inserida</returns>       
        [HttpPost]
        public async Task<IActionResult> Post(InscricaoDto model)
        {
            try
            {
                 var Inscricao = await _InscricaoService.Add(model);
                 if(Inscricao == null) return BadRequest("Erro ao tentar inserir Inscricao.");

                 return Ok(Inscricao);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar Inscricaoes. MSG: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza Inscricao
        /// </summary>
        /// <param name="model">DTO de Inscricao</param>
        /// <returns>DTO Inscricao atualizada</returns>
        [HttpPut]
        public async Task<IActionResult> Put(InscricaoDto model)
        {
            try
            {
                 var Inscricao = await _InscricaoService.Update(model);
                 if(Inscricao == null) return BadRequest("Erro ao tentar atualizar Inscricao.");

                 return Ok(Inscricao);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar Inscricao. Erro {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui Inscricao com id Informado
        /// </summary>
        /// <param name="id">ID da Inscricao</param>
        /// <returns>string : Deletado</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Inscricao = await _InscricaoService.GetByIdAsync(id);
                if(Inscricao == null) return NoContent();

                return await _InscricaoService.DeletarOUDesativar(id) 
                    ? Ok(new {message = "Deletado"}) 
                    : throw new Exception("Erro ao tentar excluir o Inscricao.");

            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao excluir o Inscricao. Erro {ex.Message}");
            }
        }

    }
}