using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Context
{
    public class LiveEntityTypeConfiguration : IEntityTypeConfiguration<LiveEntity>
    {
        public void Configure(EntityTypeBuilder<LiveEntity> builder)
        {
            builder.ToTable("LIVE");

            builder
                .HasOne(l => l.instrutor)
                .WithMany(i => i.lives)
                .OnDelete(DeleteBehavior.NoAction);
                    
        }
    }
}