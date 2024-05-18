using FerremasApp.Server.Modelos.ViewModels;

namespace FerremasApp.Server.Servicios
{
    public interface IUsuarioAPI
    {
        public UsuatioAPIViewmodels Autenticacion(AuthAPI authAPI);
    }
}
