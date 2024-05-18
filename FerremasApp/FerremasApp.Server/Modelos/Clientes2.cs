using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class Clientes2
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public byte[] Password { get; set; } = null!;
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Pedido Pedido { get; set; } = null!;
    }
}
