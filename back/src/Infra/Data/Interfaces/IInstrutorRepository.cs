using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Interfaces
{
    public interface IInstrutorRepository
    {
        Task<InstrutorEntity[]> GetAllAsync();            
        Task<InstrutorEntity> GetByIdAsync(int id);            
        Task<InstrutorEntity[]> GetByNomeAsync(string nome);            
    }
}