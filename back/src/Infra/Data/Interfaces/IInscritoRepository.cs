using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Interfaces
{
    public interface IInscritoRepository
    {
        Task<InscritoEntity[]> GetAllAsync();            
        Task<InscritoEntity> GetByIdAsync(int id);            
        Task<InscritoEntity[]> GetByNomeAsync(string nome);            
        Task<InscritoEntity[]> GetByLiveAsync(int idLive);            
    }
}