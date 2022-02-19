using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DTOS;

namespace APP.Interfaces
{
    public interface IPessoaService
    {
         Task<PessoaDto> Add(PessoaDto model);
         Task<PessoaDto> Update( PessoaDto model);
         Task<bool> Delete(int Id);
         Task<bool> DeletarOUDesativar(int Id);
         Task<PessoaDto[]?> GetAllAsync();
         Task<PessoaDto?> GetByIdAsync(int id);
         Task<PessoaDto?> GetByEmailAsync(string email);
         Task<PessoaDto[]?> GetByNomeAsync(string nome);
    }
}