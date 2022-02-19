using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class PessoaRepository: IPessoaRepository
    {
        private readonly LivesContext _context; 

        public PessoaRepository(LivesContext context)
        {
            this._context = context;
        }

        public async Task<PessoaEntity[]> GetAllAsync()
        {
            IQueryable<PessoaEntity> query = _context.Pessoas.AsNoTracking();

                query = query.OrderBy(p => p.nome);

                return await query.ToArrayAsync();     
        }

        public async Task<PessoaEntity> GetByIdAsync(int id)
        {
                IQueryable<PessoaEntity> query = _context.Pessoas.AsNoTracking();

                query = query.Where(a => a.id == id );

                return await query.FirstOrDefaultAsync(); 
        }
                public async Task<PessoaEntity> GetByEmailAsync(string email)
        {
                IQueryable<PessoaEntity> query = _context.Pessoas.AsNoTracking();

                query = query.Where(p => p.email == email );

                return await query.FirstOrDefaultAsync(); 
        }

        public async Task<PessoaEntity[]> GetByNomeAsync(string nome)
        {
                IQueryable<PessoaEntity> query = _context.Pessoas.AsNoTracking();

                query = query.Where(p => p.nome == nome );

                return await query.ToArrayAsync(); 
        }
    }
}