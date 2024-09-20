﻿using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Entities;
using ProduccionBack.Services;

namespace ProduccionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenProduccionController : ControllerBase
    {
        private IProduccionService service;

        public OrdenProduccionController()
        {
            service = new ProduccionService();
        }

        // GET: api/<OrdenProduccionController>
        [HttpGet("componentes")]
        public IActionResult Get()
        {
            return Ok(service.ConsultarComponentes());
        }
       
        // POST api/<OrdenProduccionController>
        [HttpPost]
        public IActionResult Post([FromBody] OrdenProduccion orden)
        {
            try { 
                if(orden == null)
                {
                    return BadRequest("Se esperaba una orden de producción completa");
                }
                if (service.RegistrarProduccion(orden))
                    return Ok("Orden registrada con éxito!");
                else
                    return StatusCode(500, "No se pudo registrar la orden!");
            }
            catch (Exception )
            {
                return StatusCode(500, "Error interno, intente nuevamente!");
            }
        }

        // GET de ordenes 

        [HttpGet("ordenes")]

        public IActionResult GetOrders([FromQuery]DateTime? f, string? estado)
        {
            try
            {
                var list = service.ConsultarOrdenes(f, estado);
                if(list.Count == 0)
                {
                    return NotFound("No hubo coincidencias.");
                }
                else
                {
                    return Ok(list);
                }
                
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Hubo un error");
                throw exc;
            }
        }
    }
}
