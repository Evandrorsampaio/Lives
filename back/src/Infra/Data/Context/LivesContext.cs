using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class LivesContext: DbContext
    {
        public LivesContext()
        {
            
        }
        public LivesContext(DbContextOptions<LivesContext> options): base(options)
        {
        }

        public DbSet<LiveEntity>? Lives { get; set; }
        public DbSet<PessoaEntity>? Pessoas { get; set; }
        public DbSet<InscritoEntity>? Inscritos { get; set; }
        public DbSet<InstrutorEntity>? Instrutores { get; set; }
        public DbSet<InscricaoEntity>? Inscricoes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(  stringconne con "server=localhost\\SQLEXPRESS;database=Lives;user=lives_api;password=Teste@Sponte2022");
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=Lives;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            new InscricaoEntityTypeConfiguration().Configure(modelBuilder.Entity<InscricaoEntity>());
            new PessoaEntityTypeConfiguration().Configure(modelBuilder.Entity<PessoaEntity>());
            new LiveEntityTypeConfiguration().Configure(modelBuilder.Entity<LiveEntity>());
            new InscritoEntityTypeConfiguration().Configure(modelBuilder.Entity<InscritoEntity>());
            new InstrutorEntityTypeConfiguration().Configure(modelBuilder.Entity<InstrutorEntity>());

        }
    }
}