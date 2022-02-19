using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Interfaces
{
    public interface IInscricaoRepository
    {
        Task<InscricaoEntity> GetAllAsync();
        Task<InscricaoEntity> GetByIdAsync(int id);
        Task<InscricaoEntity[]> GetByInscritoAsync(int idInscrito);            
        Task<InscricaoEntity[]> GetByLiveAsync(int idLive);            
    }
}