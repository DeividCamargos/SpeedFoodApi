
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedFoodApi2.Models;

namespace SpeedFoodApi2.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItem");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Quantidade).HasColumnType("int").IsRequired();
            builder.Property(p => p.Valor).HasColumnType("decimal(10,2)").IsRequired(); 
        }
    }
}
