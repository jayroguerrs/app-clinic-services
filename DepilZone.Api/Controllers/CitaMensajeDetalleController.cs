using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CitaMensajeDetalleController : Controller
    {

        private readonly ICitaMensajeDetalleApp _detalle;

        public CitaMensajeDetalleController(ICitaMensajeDetalleApp DetalleApp)
        {
            this._detalle = DetalleApp;
        }
        [HttpGet]
        [CustomFilter("000280")]
        public async Task<IEnumerable<CitaMensajeDetalleEnt>> Get()
        {
            return await _detalle.Obtener();
        }
        [HttpPost]
        [CustomFilter("000281")]
        public async Task<Respuesta<CitaMensajeDetalleEnt>> Post(CitaMensajeDetalleEnt model)
        {
            return await _detalle.Insertar(model);
        }
        [HttpPut("{id}")]
        [CustomFilter("000282")]
        public async Task<Respuesta<CitaMensajeDetalleEnt>> Put(CitaMensajeDetalleEnt model)
        {
            return await _detalle.Modificar(model);
        }
        [HttpGet("{id}")]
        [CustomFilter("000283")]
        public async Task<CitaMensajeDetalleEnt> Get(int id)
        {
            return await _detalle.ObtenerById(id);
        }
        [HttpGet("cita/{idCita}")]
        [CustomFilter("000284")]
        public async Task<ActionResult> ListarByCita(int idCita)
        {
            try
            {
                return Ok(new
                {
                    data = await _detalle.ListarByCita(idCita),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new {},
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
