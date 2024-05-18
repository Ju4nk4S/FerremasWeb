using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class Cliente
    {
        public Cliente()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; } 
        public byte[] Password { get; set; } 
        public string Direccion { get; set; }
        public string Telefono { get; set; } 
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
