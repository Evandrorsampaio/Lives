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
    public class LiveController : ControllerBase
    {

       private readonly ILiveService _liveService;
        public LiveController(
            ILiveService liveService
        )
        {
            this._liveService = liveService;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var live = await _liveService.GetAllAsync();
                 if(live == null) return NoContent();

                 return Ok(live);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Lives. MSG: {ex.Message}");
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var live = await _liveService.GetByIdAsync(id);
                 if(live == null) return NoContent();

                 return Ok(live);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Lives. MSG: {ex.Message}");
            }
        }

        [Route("PorNome/{nome}")]
        [HttpGet]
        public async Task<IActionResult> GetPorNome(string nome)
        {
            try
            {
                 var live = await _liveService.GetByNomeAsync(nome);
                 if(live == null) return NoContent();

                 return Ok(live);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar Lives. MSG: {ex.Message}");
            }
        
        }

        /// <summary>
        /// Insere Live
        /// </summary>
        /// <param name="model">DTO de Live</param>
        /// <returns>DTO da Live Inserida</returns>       
        [HttpPost]
        public async Task<IActionResult> Post(LiveDto model)
        {
            try
            {
                 var Live = await _liveService.Add(model);
                 if(Live == null) return BadRequest("Erro ao tentar inserir live.");

                 return Ok(Live);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar Lives. MSG: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza Live
        /// </summary>
        /// <param name="model">DTO de Live</param>
        /// <returns>DTO Live atualizada</returns>
        [HttpPut]
        public async Task<IActionResult> Put(LiveDto model)
        {
            try
            {
                 var Live = await _liveService.Update(model);
                 if(Live == null) return BadRequest("Erro ao tentar atualizar live.");

                 return Ok(Live);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar Live. Erro {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui Live com id Informado
        /// </summary>
        /// <param name="id">ID da Live</param>
        /// <returns>string : Deletado</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Live = await _liveService.GetByIdAsync(id);
                if(Live == null) return NoContent();

                return await _liveService.DeletarOUDesativar(id) 
                    ? Ok(new {message = "Deletado"}) 
                    : throw new Exception("Erro ao tentar excluir o Live.");

            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao excluir o Live. Erro {ex.Message}");
            }
        }

    }
}