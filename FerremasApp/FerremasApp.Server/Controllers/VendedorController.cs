using FerremasApp.Server.Modelos.ViewModels;
using FerremasApp.Server.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FerremasApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {

        private readonly IConfiguration configuration;
        public VendedorController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }





        [HttpGet]
        public IActionResult DameVendedor()
        {
            Resultado res = new Resultado();
            try
            {
                using (FerremasAppContext basedatos = new FerremasAppContext())
                {
                    var lista = basedatos.Vendedors.ToList();
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                res.Error = "Error al obtener usuarios" + ex.Message;
            }

            return Ok(res);
        }
        [HttpPost]
        public IActionResult AgregarVendedor(VendedorViewmodel v)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);

                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    Vendedor vendedor = new Vendedor();
                    vendedor.Nombre = v.nombre;
                    vendedor.Usuario = v.usuario;
                    vendedor.Password = Encoding.ASCII.GetBytes(s: util.cifrar(v.pass, configuration["ClaveCifrado"]));

                    basedatos.Vendedors.Add(vendedor);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al obtener al obtener el alta " + ex.Message;
            }

            return Ok(res);
        }

        [HttpPut]
        public IActionResult EditarVendedor(VendedorViewmodel v)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);

                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    Vendedor vendedor= basedatos.Vendedors.Single(ven => ven.Usuario == v.usuario);
                    vendedor.Nombre = v.nombre;
                    vendedor.Usuario = v.usuario;
                    vendedor.Password = Encoding.ASCII.GetBytes(util.cifrar(v.pass, configuration["ClaveCifrado"]));
                    basedatos.Entry(vendedor).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al modificar un vendedor " + ex.Message;
            }

            return Ok(res);
        }

        [HttpDelete("{Usuario}")]
        public IActionResult BorrarCliente(String Vendedor)
        {
            Resultado res = new Resultado();
            try
            {

                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    Vendedor vendedor = basedatos.Vendedors.Single(ven => ven.Usuario == Vendedor);
                    basedatos.Remove(vendedor);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al borrar un vendedor " + ex.Message;
            }

            return Ok(res);
        }
    }
}
