using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Producto> Productos = new List<Producto>();

        [HttpGet]

        public IActionResult Get()
        {
            Productos.Add(new Producto() { Codigo = 1, Nombre = "Producto 1" });
            return Ok(Productos);
        }
    }
}
