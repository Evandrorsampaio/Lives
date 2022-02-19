using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data.Interfaces
{
    public interface IPessoaRepository
    {
        Task<PessoaEntity[]> GetAllAsync();            
        Task<PessoaEntity> GetByIdAsync(int id);            
        Task<PessoaEntity> GetByEmailAsync(string email);            
        Task<PessoaEntity[]> GetByNomeAsync(string nome);       
    }
}