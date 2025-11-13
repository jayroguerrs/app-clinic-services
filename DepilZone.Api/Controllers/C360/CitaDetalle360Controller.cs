using DepilZone.Api.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Http;
using DepilZone.Entidad.Exceptions;
using System;
using DepilZone.Application.Interface;
using System.Collections.Generic;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Application.Interface.C360;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers.C360
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaDetalle360Controller : ControllerBase
    {
        private readonly ICitaDetalle360App _CitaDetalle360;
        private readonly IHubContext<SignalHub> _hubContext;

        public CitaDetalle360Controller(ICitaDetalle360App CitaDetalle360App, IHubContext<SignalHub> hubContext)
        {
            _CitaDetalle360 = CitaDetalle360App;
            _hubContext = hubContext;
        }


        [HttpGet("cita/{idCita}")]
        [CustomFilter("000529")]
        public async Task<ActionResult> Get(int idCita)
        {
            try
            {
                List<Cita360DetallesDTO> collection = await _CitaDetalle360.BuscarByCita(idCita);
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