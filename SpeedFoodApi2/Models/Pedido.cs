using System;
using System.Collections.Generic;

namespace SpeedFoodApi2.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public ICollection<PedidoItem> Itens { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Data { get; set; } 
    }
}
