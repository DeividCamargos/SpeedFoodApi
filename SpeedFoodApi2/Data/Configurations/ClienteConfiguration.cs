
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedFoodApi2.Models;

namespace SpeedFoodApi2.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("varchar(80)").IsRequired(); 
            builder.Property(p => p.Telefone).HasColumnType("char(11)").IsRequired();
            builder.Property(p => p.Rua).HasColumnType("varchar(60)").IsRequired();
            builder.Property(p => p.Bairro).HasColumnType("varchar(60)").IsRequired();
            builder.Property(p => p.Numero).HasColumnType("varchar(4)").IsRequired();
            builder.Property(p => p.Complemento).HasColumnType("varchar(200)");
        }
    }
}
