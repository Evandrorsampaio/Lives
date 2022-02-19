using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context
{
    public class InscricaoEntityTypeConfiguration : IEntityTypeConfiguration<InscricaoEntity>
    {
        public void Configure(EntityTypeBuilder<InscricaoEntity> builder)
        {
            builder.ToTable("INSCRICAO");

            builder
                .HasKey(i => i.id);

            builder
                .HasOne(i => i.inscrito)
                .WithMany(insc => insc.inscricoes)
                .OnDelete(DeleteBehavior.NoAction);
            
            builder
                .HasOne(i => i.live)
                .WithMany(l => l.inscricoes)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}