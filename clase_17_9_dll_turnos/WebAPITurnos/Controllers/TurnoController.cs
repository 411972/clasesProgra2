using Microsoft.AspNetCore.Mvc;
using TurnosBack.Entities;
using TurnosBack.Repositories.Implementation;
using TurnosBack.Services.Contracts;
using TurnosBack.Services.Implementations;

namespace WebAPITurnos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TurnoController : Controller
    {
        private readonly ITurnoService _turnoService;
        public TurnoController()
        {
            _turnoService = new TurnoService();
        }

        [HttpPost]
        public IActionResult PostTurno([FromBody] Turno turno)
        {
            try
            {
                if (_turnoService.InsertarMaestroDetalle(turno))
                {
                    return Ok("Insertado");
                }
                else
                {
                    return BadRequest("No se pudo");
                }
            }
            catch (Exception exc)
            {
                return StatusCode(500, "ERROR");
                throw exc;
            }

            
        }
    }
}
