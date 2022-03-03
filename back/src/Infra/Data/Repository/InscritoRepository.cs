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
    public class InscritoRepository: IInscritoRepository
    {
        private readonly LivesContext _context; 

        public InscritoRepository(LivesContext context)
        {
            this._context = context;
        }

        public async Task<InscritoEntity[]> GetAllAsync()
        {
            IQueryable<InscritoEntity> query = _context.Inscritos.AsNoTracking();

                query = query.Include(i => i.pessoa)
                            .OrderBy(i => i.pessoa.nome);

                return await query.ToArrayAsync();     
        }

        public async Task<InscritoEntity> GetByEmailAsync(string email)
        {
                IQueryable<InscritoEntity> query = _context.Inscritos.AsNoTracking();

                query = query.Include(i => i.pessoa)
                            .Include(i => i.inscricoes).ThenInclude(insc => insc.live)
                            .Where(i => i.pessoa.email == email );

                return await query.FirstOrDefaultAsync(); 
        }

        public async Task<InscritoEntity> GetByIdAsync(int id)
        {
                IQueryable<InscritoEntity> query = _context.Inscritos.AsNoTracking();

                query = query.Include(i => i.pessoa)
                            .Include(i => i.inscricoes).ThenInclude(insc => insc.live)
                            .Where(a => a.id == id );

                return await query.FirstOrDefaultAsync(); 
        }

        public Task<InscritoEntity[]> GetByLiveAsync(int idLive)
        {
            throw new NotImplementedException();
        }

        public async Task<InscritoEntity[]> GetByNomeAsync(string nome)
        {
               IQueryable<InscritoEntity> query = _context.Inscritos.AsNoTracking();

                query = query.Where(i => i.pessoa.nome == nome );

                return await query.ToArrayAsync(); 
         }

    }
}