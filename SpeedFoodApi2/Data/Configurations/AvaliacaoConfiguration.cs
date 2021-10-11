using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedFoodApi2.Models; 

namespace SpeedFoodApi2.Data.Configurations
{
    public class AvaliacaoConfiguration : IEntityTypeConfiguration<Avaliacao>
    {
        public void Configure(EntityTypeBuilder<Avaliacao> builder)
        {
            builder.ToTable("Avaliacao");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Descricao).HasColumnType("varchar(500)").IsRequired();
        }
    }
}
