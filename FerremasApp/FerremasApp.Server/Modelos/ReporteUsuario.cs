using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class ReporteUsuario
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string? Descripcion { get; set; }
    }
}
