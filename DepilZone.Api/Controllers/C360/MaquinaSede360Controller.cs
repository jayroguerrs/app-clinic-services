using DepilZone.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using DepilZone.Entidad.Exceptions;
using System;
using System.Collections.Generic;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Application.Interface.C360;
using DepilZone.Entidad.DTO;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers.C360
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaquinaSede360Controller : ControllerBase
    {
        private readonly IMaquinaSede360App _MaquinaSede360;
        private readonly IHubContext<SignalHub> _hubContext;

        public MaquinaSede360Controller(IMaquinaSede360App MaquinaSede360App, IHubContext<SignalHub> hubContext)
        {
            _MaquinaSede360 = MaquinaSede360App;
            _hubContext = hubContext;
        }
        [HttpGet("fecha-disponible/{fechaDesde}/{fechaHasta}/{idServicio}/{idSede}")]
        [CustomFilter("000531")]
        public async Task<ActionResult> GetFechaDisponible(DateTime fechaDesde, DateTime fechaHasta, int idServicio, int idSede)
        {
            try
            {
                List<MaquinaSede360DisponibleDTO> collection = await _MaquinaSede360.BuscarFechaDisponible(fechaDesde, fechaHasta, idServicio, idSede);
                return Ok(new
                {
                    data = collection,
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
        [HttpGet("maquina-disponible/{fecha}/{idServicio}/{idSede}")]
        [CustomFilter("000532")]
        public async Task<ActionResult> GetMaquinaDisponible(DateTime fecha, int idServicio, int idSede)
        {
            try
            {
                List<MaquinaSede360DTO> collection = await _MaquinaSede360.VerMaquinaDisponible(fecha, idServicio, idSede);
                return Ok(new
                {
                    data = collection,
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
        [HttpGet("maquina-disponible/{idMaquina}/{fecha}/{idServicio}/{idSede}")]
        [CustomFilter("000533")]
        public async Task<ActionResult> GetMaquina(int idMaquina, DateTime fecha, int idServicio, int idSede)
        {
            try
            {
                MaquinaSede360DTO output = await _MaquinaSede360.VerMaquinaDisponibleById(idMaquina, fecha, idServicio, idSede);
                return Ok(new
                {
                    data = output,
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
        [HttpPost("tecnologias/{idMaquinaSede}")]
        //[CustomFilter("000534")]
        public async Task<ActionResult> AsignarTecnologias(int idMaquinaSede, MaquinaSedeTecnologia360DTO model)
        {
            try
            {
                await _MaquinaSede360.AsignarTecnologias(idMaquinaSede, model);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status201Created
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
        [HttpGet("tecnologias/{idMaquinaSede}")]
        [CustomFilter("000535")]
        public async Task<ActionResult> ListarTecnologias(int idMaquinaSede)
        {
            try
            {
                List<TecnologiaDTO> collection = await _MaquinaSede360.ListarTecnologias(idMaquinaSede);
                return Ok(new
                {
                    data = collection,
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