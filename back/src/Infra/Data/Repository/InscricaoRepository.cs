using Data.Context;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class InscricaoRepository: IInscricaoRepository
    {
        private readonly LivesContext _context; 

        public InscricaoRepository(LivesContext context)
        {
            this._context = context;
        }


        public async Task<InscricaoEntity> GetAllAsync()
        {
                IQueryable<InscricaoEntity> query = _context.Inscricoes.AsNoTracking();

                query = query.Include(inscricao => inscricao.inscrito).ThenInclude(inscrito => inscrito.pessoa)
                            .Include(inscricao => inscricao.live)
                                .ThenInclude(live => live.instrutor)
                                    .ThenInclude(instrutor => instrutor.pessoa)
                            .OrderBy(i => i.id );

                return await query.FirstOrDefaultAsync(); 
        }
        public async Task<InscricaoEntity> GetByIdAsync(int id)
        {
                IQueryable<InscricaoEntity> query = _context.Inscricoes.AsNoTracking();

                query = query.Where(i => i.id == id );

                return await query.FirstOrDefaultAsync(); 
        }

        public async Task<InscricaoEntity[]> GetByInscritoAsync(int idInscrito)
        {
               IQueryable<InscricaoEntity> query = _context.Inscricoes.AsNoTracking();

                query = query.Where(i => i.idInscrito == idInscrito );

                return await query.ToArrayAsync(); 
        }

        public async Task<InscricaoEntity[]> GetByLiveAsync(int idLive)
        {
               IQueryable<InscricaoEntity> query = _context.Inscricoes.AsNoTracking();

                query = query.Where(i => i.idLive == idLive );

                return await query.ToArrayAsync(); 
        }

    }
}