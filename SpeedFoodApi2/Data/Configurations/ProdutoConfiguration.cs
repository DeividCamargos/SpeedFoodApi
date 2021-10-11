
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedFoodApi2.Models;

namespace SpeedFoodApi2.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).HasColumnType("varchar(80)").IsRequired();
            builder.Property(p => p.Preco).HasColumnType("decimal(10,2)").IsRequired(); 
            builder.Property(p => p.Descricao).HasColumnType("varchar(200)");
        }
    }
}
