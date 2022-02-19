using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DTOS;

namespace APP.Interfaces
{
    public interface IInscritoService
    {
         Task<InscritoDto> Add(InscritoDto model);
         Task<InscritoDto> Update( InscritoDto model);
         Task<bool> Delete(int Id);
         Task<bool> DeletarOUDesativar(int Id);
         Task<InscritoDto[]?> GetAllAsync();
         Task<InscritoDto?> GetByIdAsync(int id);
         Task<InscritoDto[]?> GetByNomeAsync(string nome);
    }
}