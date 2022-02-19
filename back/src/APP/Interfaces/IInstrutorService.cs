using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DTOS;

namespace APP.Interfaces
{
    public interface IInstrutorService
    {
         Task<InstrutorDto> Add(InstrutorDto model);
         Task<InstrutorDto> Update( InstrutorDto model);
         Task<bool> Delete(int Id);
         Task<bool> DeletarOUDesativar(int Id);
         Task<InstrutorDto[]?> GetAllAsync();
         Task<InstrutorDto?> GetByIdAsync(int id);
         Task<InstrutorDto[]?> GetByNomeAsync(string nome);
    }
}