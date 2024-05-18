using System;
using System.Collections.Generic;

namespace FerremasApp.Server.Modelos
{
    public partial class Bodegero
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Usuario { get; set; }
        public byte[]? Password { get; set; }
    }
}
