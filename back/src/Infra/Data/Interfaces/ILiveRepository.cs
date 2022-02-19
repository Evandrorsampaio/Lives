using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Interfaces
{
    public interface ILiveRepository
    {
        Task<LiveEntity[]> GetAllAsync();            
        Task<LiveEntity> GetByIdAsync(int id);            
        Task<LiveEntity[]> GetByNomeAsync(string nome);            
        Task<LiveEntity[]> GetLivesFuturasAsync(DateTime referencia);            
    }
}