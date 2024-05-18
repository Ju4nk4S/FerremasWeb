using FerremasApp.Server.Modelos.ViewModels;
using FerremasApp.Server.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using FerremasApp.Server.Servicios;
using Microsoft.AspNetCore.Authorization;

namespace FerremasApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class UsuarioAPIController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private IUsuarioAPI usuarioAPIServicio;
        public UsuarioAPIController(IConfiguration configuration, IUsuarioAPI usuarioAPIServicio)
        {
            this.configuration = configuration;
            this.usuarioAPIServicio = usuarioAPIServicio; 
        }

        //UTILIZADO DE FORMA TEMPORAL PARA EL ALTA
        [HttpPost("Alta")]
        public IActionResult AltaUsuario(AuthAPI usuarioAPI)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);
                using (FerremasAppContext basedatos = new FerremasAppContext())
                {
                    UsuariosApi api = new UsuariosApi();
                    api.Email = usuarioAPI.email;
                    api.Password = Encoding.ASCII.GetBytes(util.cifrar(usuarioAPI.password, configuration["ClaveCifrado"]));
                    api.FechaAlta = DateTime.Now;
                    basedatos.UsuariosApis.Add(api);
                    basedatos.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error  al dar el alta el usuario de API " + ex.ToString();
                res.Texto = "Se produjo un error al dar de alta. Intentalo de nuevo.";
            }

            return Ok(res);
        }


        [HttpPost]
        public IActionResult DameUsuarioAPI(AuthAPI auth)
        {
            Resultado res = new Resultado();
            try
            {
                res.ObjetoGenerico = usuarioAPIServicio.Autenticacion(auth);

            }
            catch (Exception ex)
            {
                res.Error = "Error al obtener usuarios de api" + ex.Message;
            }
            return Ok(res);



            

        }

       

    }
}
