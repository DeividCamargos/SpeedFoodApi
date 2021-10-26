using Microsoft.EntityFrameworkCore;
using SpeedFoodApi2.Models;

namespace SpeedFoodApi2.Data
{
    public class SpeedFoodContext : DbContext
    {
        public SpeedFoodContext(DbContextOptions<SpeedFoodContext> options)
               : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpeedFoodContext).Assembly);
        }
    }
}
