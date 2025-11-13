using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
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

    public class IncidenciaController : ControllerBase
    {
        private readonly IIncidenciaApp _IIncidenciaApp;

        public IncidenciaController(IIncidenciaApp IIncidenciaApp)
        {
            _IIncidenciaApp = IIncidenciaApp;
        }

        [HttpPost]
        [CustomFilter("000403")]
        public async Task<Respuesta<IncidenciaEnt>> Post(IncidenciaEnt model)
        {
            return await _IIncidenciaApp.Insertar(model);
        }
        [HttpPut]
        [CustomFilter("000404")]
        public async Task<Respuesta<IncidenciaEnt>> Put(IncidenciaEnt model)
        {
            return await _IIncidenciaApp.Modificar(model);
        }
        [HttpGet("{id}")]
        [CustomFilter("000405")]
        public async Task<IncidenciaEnt> ObtenerByid(int id)
        {
            return await _IIncidenciaApp.ObtenerById(id);
        }
        [HttpGet("listado/{idEstado}")]
        [CustomFilter("000406")]
        public async Task<IEnumerable<IncidenciaListadoGrillaDTO>> ObtenerListado(int idEstado)
        {
            return await _IIncidenciaApp.ObtenerListado(idEstado);
        }
        [HttpGet("nivelAtencion")]
        [CustomFilter("000407")]
        public async Task<ActionResult> NivelAtencion()
        {

            try
            {
                return Ok(new
                {
                    data = await _IIncidenciaApp.NivelAtencion(),
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
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
    }
}
