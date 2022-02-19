using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DTOS;

namespace APP.Interfaces
{
    public interface IInscricaoService
    {
         Task<InscricaoDto> Add(InscricaoDto model);
         Task<InscricaoDto> Update( InscricaoDto model);
         Task<bool> Delete(int Id);
         Task<bool> DeletarOUDesativar(int Id);
         Task<InscricaoDto?> GetAllAsync();
         Task<InscricaoDto?> GetByIdAsync(int id);
         Task<InscricaoDto[]?> GetByInscritoAsync(int idInscrito);
         Task<InscricaoDto[]?> GetByLiveAsync(int idLive);
    }
}