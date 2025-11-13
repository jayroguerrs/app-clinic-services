using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
    [Authorize]

    public class CitaMensajeAvisoController : Controller
	{
        private readonly ICitaMensajeAvisosApp _avisos;
        public CitaMensajeAvisoController(ICitaMensajeAvisosApp AvisosApp)
        {
            this._avisos = AvisosApp;
        }
        [HttpGet("{idCita}")]
        [CustomFilter("000276")]
        public async Task<IEnumerable<CitaMensajeAvisoEnt>> Get(int idCita)
        {
            return await _avisos.Obtener(idCita);
        }
        [HttpPost]
        [CustomFilter("000277")]
        public async Task<Respuesta<CitaMensajeAvisoEnt>> Post(CitaMensajeAvisoEnt model)
        {
            return await _avisos.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000278")]
        public async Task<Respuesta<CitaMensajeAvisoEnt>> Put(CitaMensajeAvisoEnt model)
        {
            return await _avisos.Modificar(model);
        }
        [HttpGet("cita/{idCita}")]
        [CustomFilter("000279")]
        public async Task<ActionResult> ListarByCita(int idCita)
        {
            try
            {
                return Ok(new
                {
                    data = await _avisos.ListarByCita(idCita),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        //[HttpGet("{id}")]
        //public async Task<CitaMensajeAvisoEnt> Get(int id)
        //{
        //    return await _avisos.ObtenerById(id);
        //}
    }
}
