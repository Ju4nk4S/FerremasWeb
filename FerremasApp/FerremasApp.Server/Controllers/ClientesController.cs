using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FerremasWEB.Server.Modelos;
using FerremasWEB.Server.Modelos.ViewModels;
using System.Text;
namespace FerremasWEB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ClientesController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult DameClientes()
        {
            Resultado res = new Resultado();
            try
            {
                using (FerremasWebContext basedatos = new FerremasWebContext())
                {
                    var lista = basedatos.Clientes.ToList();
                    res.ObjetoGenerico = lista;
                }
            }
            catch (Exception ex)
            {
                res.Error = "Error al obtener los clientes " + ex.Message;
            }

            return Ok(res);

        }

        [HttpPost]
        public IActionResult AgregarCliente(ClienteViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);

                using (FerremasWebContext basedatos = new FerremasWebContext())
                {

                    Cliente cliente = new Cliente();
                    cliente.Nombre = c.nombre;
                    cliente.Email = c.email;
                    cliente.Password = Encoding.ASCII.GetBytes(util.cifrar(c.pass, configuration["ClaveCifrado"]));
                    cliente.Direccion = c.drireccion;
                    cliente.Telefono = c.telefono;
                    cliente.FechaAlta = DateTime.Now;
                    basedatos.Clientes.Add(cliente);
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
        public IActionResult EditarCliente(ClienteViewmodel c)
        {
            Resultado res = new Resultado();
            try
            {
                byte[] keyBbyte = new byte[] { 1, 2, 3, 4, 5, 6, 7, 8 };
                Util util = new Util(keyBbyte);

                using (FerremasWebContext basedatos = new FerremasWebContext())
                {

                    Cliente cliente = basedatos.Clientes.Single(cli => cli.Email == c.email);
                    cliente.Nombre = c.nombre;
                    cliente.Password = Encoding.ASCII.GetBytes(util.cifrar(c.pass, configuration["ClaveCifrado"]));
                    basedatos.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al modificar un cliente " + ex.Message;
            }

            return Ok(res);
        }

        [HttpDelete("{Email}")]
        public IActionResult BorrarCliente(String Email)
        {
            Resultado res = new Resultado();
            try
            {

                using (FerremasWebContext basedatos = new FerremasWebContext())
                {

                    Cliente cliente = basedatos.Clientes.Single(cli => cli.Email == Email);
                    basedatos.Remove(cliente);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al borrar un cliente " + ex.Message;
            }

            return Ok(res);
        }


    }
}

