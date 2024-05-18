using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class Clientes2
    {
        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public string Email { get; set; } 
        public byte[] Password { get; set; } 
        public DateTime FechaAlta { get; set; } 
        public DateTime? FechaBaja { get; set; }

        public virtual Pedido Pedido { get; set; }
    }
}
