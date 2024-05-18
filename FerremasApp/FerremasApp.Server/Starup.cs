using FerremasApp.Server.Modelos;

namespace FerremasApp.Server
{
    public class Starup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Agrega el servicio UsuariosApi al contenedor de dependencias
            services.AddScoped<UsuariosApi>();

            // Otros servicios y configuraciones...
        }
    }
}
