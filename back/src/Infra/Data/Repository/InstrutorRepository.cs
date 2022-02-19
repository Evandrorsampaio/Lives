using Data.Context;
using Data.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class InstrutorRepository: IInstrutorRepository
    {
        private readonly LivesContext _context; 

        public InstrutorRepository(LivesContext context)
        {
            this._context = context;
        }

        public async Task<InstrutorEntity[]> GetAllAsync()
        {
            IQueryable<InstrutorEntity> query = _context.Instrutores.AsNoTracking();

                query = query.OrderBy(i => i.pessoa.nome);

                return await query.ToArrayAsync();     
        }

        public async Task<InstrutorEntity> GetByEmailAsync(string email)
        {
                IQueryable<InstrutorEntity> query = _context.Instrutores.AsNoTracking();

                query = query.Where(i => i.pessoa.email == email );

                return await query.FirstOrDefaultAsync(); 
        }

        public async Task<InstrutorEntity> GetByIdAsync(int id)
        {
                IQueryable<InstrutorEntity> query = _context.Instrutores.AsNoTracking();

                query = query.Where(a => a.id == id );

                return await query.FirstOrDefaultAsync(); 
        }

        public async Task<InstrutorEntity[]> GetByNomeAsync(string nome)
        {
               IQueryable<InstrutorEntity> query = _context.Instrutores.AsNoTracking();

                query = query.Where(i => i.pessoa.nome == nome );

                return await query.ToArrayAsync(); 
         }

    }
}