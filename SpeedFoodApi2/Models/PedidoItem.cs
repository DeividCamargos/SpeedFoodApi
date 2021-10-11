using System; 

namespace SpeedFoodApi2.Models
{
    public class PedidoItem
    {
        public int Id { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public decimal? Valor { get; set; }
        public int Quantidade { get; set; }
        public Produto Produto { get; set; }
        public Pedido Pedido { get; set; }
    }
}
