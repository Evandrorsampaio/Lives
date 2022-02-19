using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context
{
    public class PessoaEntityTypeConfiguration : IEntityTypeConfiguration<PessoaEntity>
    {
        public void Configure(EntityTypeBuilder<PessoaEntity> builder)
        {
            builder.ToTable("PESSOA");
        }
    }
}