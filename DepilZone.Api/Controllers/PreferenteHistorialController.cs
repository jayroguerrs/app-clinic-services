using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using DepilZone.Entidad.DTO;
using DepilZone.Data.Response;
using Microsoft.AspNetCore.Authorization;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers
{
    [Route("api/preferente-historial")]
    [ApiController]
    [Authorize]

    public class PreferenteHistorialController : ControllerBase
    {
        private readonly IPreferenteHistorialApp _PreferenteHistorial;

        public PreferenteHistorialController(IPreferenteHistorialApp PreferenteHistorialApp, IHubContext<SignalHub> hubContext)
        {
            _PreferenteHistorial = PreferenteHistorialApp;
        }

        [HttpGet("{idPreferente}")]
        [CustomFilter("000421")]
        public async Task<ActionResult> Get(int idPreferente)
        {
            try
            {
                List<PreferenteHistorialDTO> data = await _PreferenteHistorial.Obtener(idPreferente);
                return Ok(new JsonResponse()
                {
                    Data = data,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException e)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
            catch (Exception e)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
                throw e;
            }
        }
    }

}

