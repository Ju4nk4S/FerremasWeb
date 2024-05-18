using FerremasApp.Server.Modelos.ViewModels;
using FerremasApp.Server.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FerremasApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ReporteController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult DameReporte()
        {
            Resultado res = new Resultado();
            try
            {
                using (FerremasAppContext basedatos = new FerremasAppContext())
                {
                    var lista = basedatos.Productos.ToList();
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                res.Error = "Error al obtener reporte" + ex.Message;
            }

            return Ok(res);
        }
        [HttpPost]
        public IActionResult AgregarReporte(ReporteViewmodel r)
        {
            Resultado res = new Resultado();
            try
            {


                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    ReporteUsuario reporte = new ReporteUsuario();
                    
                    reporte.Descripcion = r.descripcion;
                    basedatos.ReporteUsuarios.Add(reporte);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al agregar reporte " + ex.Message;
            }

            return Ok(res);
        }

        [HttpPut]
        public IActionResult EditarReporte(ReporteViewmodel r)
        {
            Resultado res = new Resultado();
            try
            {


                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    ReporteUsuario reporte = new ReporteUsuario();

                    reporte.Descripcion = r.descripcion;
                    basedatos.ReporteUsuarios.Add(reporte);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al modificar el reporte " + ex.Message;
            }

            return Ok(res);
        }

        [HttpDelete("{IdUsuario}")]
        public IActionResult BorrarCliente(String Nombre)
        {
            Resultado res = new Resultado();
            try
            {

                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    ReporteUsuario reporte = new ReporteUsuario();
                    basedatos.Remove(reporte);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al borrar el reporte " + ex.Message;
            }

            return Ok(res);
        }
    }
}
