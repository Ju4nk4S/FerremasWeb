using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class UsuariosApi
    {
        public int Id { get; set; }
        public string Email { get; set; } 
        public byte[] Password { get; set; } 
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
    }
}
