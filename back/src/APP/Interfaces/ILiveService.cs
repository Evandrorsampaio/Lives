using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APP.DTOS;

namespace APP.Interfaces
{
    public interface ILiveService
    {
         Task<LiveDto> Add(LiveDto model);
         Task<LiveDto> Update( LiveDto model);
         Task<bool> Delete(int Id);
         Task<bool> DeletarOUDesativar(int Id);
         Task<LiveDto[]?> GetAllAsync();
         Task<LiveDto?> GetByIdAsync(int id);
         Task<LiveDto[]?> GetByNomeAsync(string nome);
    }
}