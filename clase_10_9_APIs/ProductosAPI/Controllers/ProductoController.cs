using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Models;
using ProductosAPI.Services;

namespace ProductosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductoController : Controller
    {
        private IAplicacion _instancia;

        public ProductoController()
        {
            _instancia = new ProductoService();
        }

        [HttpGet]

        public IActionResult getProducts()
        {
            return Ok(_instancia.getProducts());
        }

        public IActionResult PostProduct(Producto p)
        {
            var result = _instancia.AgregarProducto(p);
            if (result)
            {
                return Ok("agregado");
            }
            else
            {
                return BadRequest("no");
            }
        }
    }
}
