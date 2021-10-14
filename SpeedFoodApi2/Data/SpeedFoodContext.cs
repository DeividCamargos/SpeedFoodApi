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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SpeedFoodDb;User=sa;Password=abcd.1234;ConnectRetryCount=0;MultipleActiveResultSets=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpeedFoodContext).Assembly);
        }
    }
}
