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
        public string Nombre { get; set; } = null!;
        public string Categoria { get; set; } = null!;
        public string Marca { get; set; } = null!;
        public string Modelo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal? Precio { get; set; }

        public virtual ICollection<LineaPedido> LineaPedidos { get; set; }
    }
}
