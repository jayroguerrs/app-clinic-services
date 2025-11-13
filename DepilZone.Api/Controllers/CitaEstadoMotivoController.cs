using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class CitaEstadoMotivoController : ControllerBase
    {
        public readonly ICitaEstadoMotivoApp _ICitaEstadoMotivoApp;
        public CitaEstadoMotivoController(ICitaEstadoMotivoApp ICitaEstadoMotivoApp)
        {
            _ICitaEstadoMotivoApp = ICitaEstadoMotivoApp;
        }

        [HttpGet]
        [CustomFilter("000269")]
        public async Task<ActionResult<List<CitaEstadoMotivoEnt>>> Listar()
        {
            try
            {
                var collection = await _ICitaEstadoMotivoApp.Listar();
                return Ok(new{
                    data = collection,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new{
                    data = new {},
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpPost]
        [CustomFilter("000270")]
        public async Task<ActionResult<CitaEstadoMotivoEnt>> Grabar( CitaEstadoMotivoDTO model  )
        {
            try
            {
                var result = await _ICitaEstadoMotivoApp.Grabar(model);
                return Ok(new
                {
                    data = result,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
        [HttpGet("reporteGeneral/{IdSede}/{Fdesde}/{Fhasta}/{IdCitaEstado}")]
        [CustomFilter("000271")]
        public async Task<ActionResult<List<CitaEstadoMotivoRespuestaEnt>>> ObtenerReporteGeneral( int IdSede, DateTime? Fdesde, DateTime? Fhasta, int IdCitaEstado)
        {
            try
            {
                CitaEstado_ParametrosDTO parametros = new CitaEstado_ParametrosDTO()
                {
                    IdSede = IdSede, 
                    Fdesde = Fdesde,
                    Fhasta = Fhasta,
                    IdCitaEstado = IdCitaEstado
                };
                var collection = await _ICitaEstadoMotivoApp.ObtenerReporteGeneral(parametros);
                return Ok(new
                {
                    data = collection,
                    mensaje = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    data = new { },
                    mensaje = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }
    }
}
