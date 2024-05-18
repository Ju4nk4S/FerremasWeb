using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class Producto
    {
        public Producto()
        {
            LineaPedidos = new HashSet<LineaPedido>();
        }

        public int Id { get; set; } 
        public string Nombre { get; set; } 
        public string Categoria { get; set; } 
        public string Marca { get; set; } 
        public string Modelo { get; set; } 
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }

        public virtual ICollection<LineaPedido> LineaPedidos { get; set; }
    }
}
