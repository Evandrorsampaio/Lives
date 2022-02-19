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
    public class LiveRepository: ILiveRepository
    {
        private readonly LivesContext _context; 

        public LiveRepository(LivesContext context)
        {
            this._context = context;
        }

        public async Task<LiveEntity[]> GetAllAsync()
        {
            IQueryable<LiveEntity> query = _context.Lives.AsNoTracking();
                query = query.Include(l => l.inscricoes)
                                .Include(l => l.instrutor);
                                
                query = query.OrderByDescending(l => l.dtHrInicio);

                return await query.ToArrayAsync();     
        }

        public async Task<LiveEntity[]> GetLivesFuturasAsync(DateTime referencia)
        {
                IQueryable<LiveEntity> query = _context.Lives.AsNoTracking();

                query = query.Where(l => l.dtHrInicio > referencia );

                return await query.ToArrayAsync(); 
        }

        public async Task<LiveEntity> GetByIdAsync(int id)
        {
                IQueryable<LiveEntity> query = _context.Lives.AsNoTracking();
                query = query.Include(l => l.instrutor)
                                .Include(l => l.inscricoes);
                query = query.Where(l => l.id == id );

                return await query.FirstOrDefaultAsync(); 
        }
        public async Task<LiveEntity[]> GetByNomeAsync(string nome)
        {
                IQueryable<LiveEntity> query = _context.Lives.AsNoTracking();
                query = query.Include(l => l.instrutor)
                                .Include(l => l.inscricoes);
                query = query.Where(l => l.nome == nome );

                return await query.ToArrayAsync(); 
        }    }
}