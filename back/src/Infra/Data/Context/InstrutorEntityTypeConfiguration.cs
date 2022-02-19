using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context
{
    public class InstrutorEntityTypeConfiguration : IEntityTypeConfiguration<InstrutorEntity>
    {
        public void Configure(EntityTypeBuilder<InstrutorEntity> builder)
        {
            builder.ToTable("INSTRUTOR");

            builder
                .HasMany(i => i.lives)
                .WithOne(l => l.instrutor)
                .OnDelete(DeleteBehavior.NoAction);

            builder
                .HasOne(i => i.pessoa);        

        }
    }
}