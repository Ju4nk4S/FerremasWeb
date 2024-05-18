using FerremasApp.Server.Modelos.ViewModels;
using FerremasApp.Server.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace FerremasApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IConfiguration configuration;
        public ProductosController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        [HttpGet]
        public IActionResult DameProductos()
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
                res.Error = "Error al obtener productos" + ex.Message;
            }

            return Ok(res);
        }
        [HttpPost]
        public IActionResult AgregarProductos(ProductoViewmodel p)
        {
            Resultado res = new Resultado();
            try
            {
            

                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    Producto producto = new Producto();
                    producto.Nombre = p.nombre;
                    producto.Categoria = p.categoria;
                    producto.Marca = p.marca;
                    producto.Modelo = p.modelo;
                    producto.Descripcion = p.descripcion;
                    basedatos.Productos.Add(producto);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al obtener producto " + ex.Message;
            }

            return Ok(res);
        }

        [HttpPut]
        public IActionResult EditarCliente(ProductoViewmodel p)
        {
            Resultado res = new Resultado();
            try
            {
                
                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    Producto producto = new Producto();
                    producto.Nombre = p.nombre;
                    producto.Categoria = p.categoria;
                    producto.Marca = p.marca;
                    producto.Modelo = p.modelo;
                    producto.Descripcion = p.descripcion;
                    basedatos.Productos.Add(producto);
                    basedatos.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = "Se produjo un error al modificar producto " + ex.Message;
            }

            return Ok(res);
        }

        [HttpDelete("{Nombre}")]
        public IActionResult BorrarCliente(String Nombre)
        {
            Resultado res = new Resultado();
            try
            {

                using (FerremasAppContext basedatos = new FerremasAppContext())
                {

                    Producto producto = basedatos.Productos.Single(pro => pro.Nombre == Nombre);
                    basedatos.Remove(producto);
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

