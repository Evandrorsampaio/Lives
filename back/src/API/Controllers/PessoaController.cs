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
    public class PessoaController : ControllerBase
    {

       private readonly IPessoaService _pessoaService;
        public PessoaController(
            IPessoaService pessoaService
        )
        {
            this._pessoaService = pessoaService;
        }
 
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                 var Pessoa = await _pessoaService.GetAllAsync();
                 if(Pessoa == null) return NoContent();

                 return Ok(Pessoa);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoas. MSG: {ex.Message}");
            }
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                 var Pessoa = await _pessoaService.GetByIdAsync(id);
                 if(Pessoa == null) return NoContent();

                 return Ok(Pessoa);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoas. MSG: {ex.Message}");
            }
        }

        [Route("PorNome/{nome}")]
        [HttpGet]
        public async Task<IActionResult> GetPorNome(string nome)
        {
            try
            {
                 var Pessoa = await _pessoaService.GetByNomeAsync(nome);
                 if(Pessoa == null) return NoContent();

                 return Ok(Pessoa);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoas. MSG: {ex.Message}");
            }
        
        }

        /// <summary>
        /// Insere Pessoa
        /// </summary>
        /// <param name="model">DTO de Pessoa</param>
        /// <returns>DTO da Pessoa Inserida</returns>       
        [HttpPost]
        public async Task<IActionResult> Post(PessoaDto model)
        {
            try
            {
                 var Pessoa = await _pessoaService.Add(model);
                 if(Pessoa == null) return BadRequest("Erro ao tentar inserir Pessoa.");

                 return Ok(Pessoa);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar Pessoas. MSG: {ex.Message}");
            }
        }

        /// <summary>
        /// Atualiza Pessoa
        /// </summary>
        /// <param name="model">DTO de Pessoa</param>
        /// <returns>DTO Pessoa atualizada</returns>
        [HttpPut]
        public async Task<IActionResult> Put(PessoaDto model)
        {
            try
            {
                 var Pessoa = await _pessoaService.Update(model);
                 if(Pessoa == null) return BadRequest("Erro ao tentar atualizar Pessoa.");

                 return Ok(Pessoa);
            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar Pessoa. Erro {ex.Message}");
            }
        }

        /// <summary>
        /// Exclui Pessoa com id Informado
        /// </summary>
        /// <param name="id">ID da Pessoa</param>
        /// <returns>string : Deletado</returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var Pessoa = await _pessoaService.GetByIdAsync(id);
                if(Pessoa == null) return NoContent();

                return await _pessoaService.DeletarOUDesativar(id) 
                    ? Ok(new {message = "Deletado"}) 
                    : throw new Exception("Erro ao tentar excluir o Pessoa.");

            }
            catch (Exception ex )
            {
                return this.StatusCode( StatusCodes.Status500InternalServerError,
                $"Erro ao excluir o Pessoa. Erro {ex.Message}");
            }
        }

    }
}