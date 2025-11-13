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
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers.C360
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaSeguimiento360Controller : ControllerBase
    {
        private readonly ICitaSeguimiento360App _CitaSeguimiento360;
        private readonly IHubContext<SignalHub> _hubContext;

        public CitaSeguimiento360Controller(ICitaSeguimiento360App CitaSeguimiento360App, IHubContext<SignalHub> hubContext)
        {
            _CitaSeguimiento360 = CitaSeguimiento360App;
            _hubContext = hubContext;
        }


        [HttpGet("cita/{idCita}")]
        //[CustomFilter("000530")]
        public async Task<ActionResult> Get(int idCita)
        {
            try
            {
                List<Cita360SeguimientoDTO> collection = await _CitaSeguimiento360.BuscarByCita(idCita);
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