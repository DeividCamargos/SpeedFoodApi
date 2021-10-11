
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpeedFoodApi2.Models;

namespace SpeedFoodApi2.Data.Configurations
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Data).HasColumnType("datetime").HasDefaultValueSql("getdate()").ValueGeneratedOnAdd().IsRequired();

            builder.HasMany(p => p.Itens)
                   .WithOne(p => p.Pedido)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
