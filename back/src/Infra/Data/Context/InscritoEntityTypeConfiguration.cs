using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context
{
    public class InscritoEntityTypeConfiguration : IEntityTypeConfiguration<InscritoEntity>
    {
        public void Configure(EntityTypeBuilder<InscritoEntity> builder)
        {
            builder.ToTable("INSCRITO");

            builder
                .HasMany(i => i.inscricoes)
                .WithOne(insc => insc.inscrito)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(i => i.pessoa);        
        }
    }
}