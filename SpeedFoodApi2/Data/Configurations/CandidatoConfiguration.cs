 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedFoodApi2.Models; 

namespace SpeedFoodApi2.Data.Configurations
{
    public class CandidatoConfiguration : IEntityTypeConfiguration<Candidato>
    {
        public void Configure(EntityTypeBuilder<Candidato> builder)
        {
            builder.ToTable("Candidato");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.DataNascimento).HasColumnType("datetime2").IsRequired();
            builder.Property(p => p.CPF).HasColumnType("char(11)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar(80)");
            builder.Property(p => p.Telefone).HasColumnType("char(11)").IsRequired();
            builder.Property(p => p.Estado).HasColumnType("char(2)").IsRequired();
            builder.Property(p => p.Cidade).HasColumnType("varchar(60)").IsRequired();
            builder.Property(p => p.Sexo).HasConversion<string>().IsRequired();
            builder.Property(p => p.Disponibilidade).HasConversion<string>().IsRequired();
        }
    }
}
