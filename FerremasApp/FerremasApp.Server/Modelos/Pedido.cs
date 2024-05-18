using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class Pedido
    {
        public Pedido()
        {
            LineaPedidos = new HashSet<LineaPedido>();
        }

        public int Id { get; set; }
        public int IdCliente { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaPedido { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; } = null!;
        public virtual Clientes2 IdNavigation { get; set; } = null!;
        public virtual ICollection<LineaPedido> LineaPedidos { get; set; }
    }
}
