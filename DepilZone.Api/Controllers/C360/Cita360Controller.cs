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
    public class Cita360Controller : ControllerBase
    {
        private readonly ICita360App _Cita360;
        private readonly IHubContext<SignalHub> _hubContext;

        public Cita360Controller(ICita360App Cita360App, IHubContext<SignalHub> hubContext)
        {
            _Cita360 = Cita360App;
            _hubContext = hubContext;
        }

        [HttpPost]
        [CustomFilter("000518")]
        public async Task<ActionResult> Post(Cita360DTO model)
        {
            try
            {
                await _Cita360.Insertar(model);
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
        [HttpPut("{idCita}")]
        [CustomFilter("000519")]
        public async Task<ActionResult> Put(int idCita, Cita360DTO model)
        {
            try
            {
                await _Cita360.Modificar(idCita, model);
                return Ok(new
                {
                    data = new { },
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
        [HttpGet("cronograma/{idCronograma}")]
        [CustomFilter("000520")]
        public async Task<ActionResult> Get(int idCronograma)
        {
            try
            {
                List<Cita360DTO> collection = await _Cita360.BuscarByCronograma(idCronograma);
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
        [HttpGet("{idCita}")]
        [CustomFilter("000521")]
        public async Task<ActionResult> GetById(int idCita)
        {
            try
            {
                Cita360DTO output = await _Cita360.BuscarById(idCita);
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
        [HttpPut("cancelar")]
        public async Task<ActionResult> Cancel(Cita360DTO model)
        {
            try
            {
                await _Cita360.Cancelar(model);
                return Ok(new
                {
                    data = new { },
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
        [HttpPut("pendiente")]
        public async Task<ActionResult> Earring(Cita360DTO model)
        {
            try
            {
                await _Cita360.Pendiente(model);
                return Ok(new
                {
                    data = new { },
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
        [HttpPut("anular")]
        public async Task<ActionResult> Bad(Cita360DTO model)
        {
            try
            {
                await _Cita360.Anular(model);
                return Ok(new
                {
                    data = new { },
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
        [HttpPut("confirmar")]
        [CustomFilter("000525")]
        public async Task<ActionResult> Confirm(Cita360DTO model)
        {
            try
            {
                await _Cita360.Confirmar(model);
                return Ok(new
                {
                    data = new { },
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
        [HttpPut("confirmarAsistencia")]
        public async Task<ActionResult> ConfirmAsistencia(Cita360DTO model)
        {
            try
            {
                await _Cita360.ConfirmarAsistencia(model);
                return Ok(new
                {
                    data = new { },
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
        [HttpPut("atender")]
        //! Review becaus user doen't have access [CustomFilter("000527")]
        public async Task<ActionResult> attend(Cita360DTOAtender model)
        {
            try
            {
                await _Cita360.Atender(model);
                return Ok(new
                {
                    data = new { },
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
        [HttpPut("nollamar")]
        public async Task<ActionResult> notCall(Cita360DTO model)
        {
            try
            {
                await _Cita360.NoLlamar(model);
                return Ok(new
                {
                    data = new { },
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