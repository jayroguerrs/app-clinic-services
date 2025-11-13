using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class HistorialOperacionesController : ControllerBase
    {
        private readonly IHistorialOperacionesApp _HistorialOperaciones;
        public HistorialOperacionesController(IHistorialOperacionesApp HistorialOperacionesApp)
        {
            _HistorialOperaciones = HistorialOperacionesApp;
        }

        [HttpGet("envio-masivo-mensaje")]
        [CustomFilter("000402")]
        public async Task<ActionResult> ListarHistorialEnvioMasivoMensaje()
        {
            try
            {
                var lista = await _HistorialOperaciones.ListarHistorialEnvioMasivoMensaje();
                return Ok(new
                {
                    data = lista,
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
                return BadRequest(new { 
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }        
    }
}
