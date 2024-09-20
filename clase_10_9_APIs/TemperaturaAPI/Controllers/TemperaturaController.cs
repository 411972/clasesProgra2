using Microsoft.AspNetCore.Mvc;
using TemperaturaAPI.Models;
using TemperaturaAPI.Utils;

namespace TemperaturaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemperaturaController : Controller
    {
        [HttpGet]
        public IActionResult GetTemperaturas()
        {
            return Ok(TemperaturaSingleton.getInstance().ObtenerTemperaturas());
        }

        [HttpPost]

        public IActionResult PostTemp(Temperatura t)
        {
            if (TemperaturaSingleton.getInstance().AgregarTemperatura(t))
            {
                return Ok("Se creó");
            }
            else
            {
                return BadRequest("NOP");
            }
            
        }

        [HttpGet("{valo}")]

        public IActionResult GetTemperaturaByValue(float valo)
        {
            Temperatura t = TemperaturaSingleton.getInstance().ObtenerTemperaturaPorValor(valo);

            if(t != null)
            {
                return Ok(t);
            }
            else
            {
                return NotFound("No hubo coincidencia");
            }
        }
    }
}
