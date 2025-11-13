using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [Authorize]
    public class ClienteEncuesta : Controller
	{
		private readonly IClienteEncuestaApp _clienteEncuestaApp;
		public ClienteEncuesta(IClienteEncuestaApp clienteEncuestaApp)
		{
			this._clienteEncuestaApp = clienteEncuestaApp;
		}

        [HttpGet("reporteGeneral/{IdSede}/{Fdesde}/{Fhasta}")]
        [CustomFilter("000326")]
        public async Task<ActionResult> ObtenerReporteGeneral(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            try
            {
                var collection = await _clienteEncuestaApp.ObtenerReporteGeneral(IdSede, Fdesde, Fhasta);
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
        [HttpGet("reporteGeneral/grafico/{IdSede}/{Fdesde}/{Fhasta}")]
        [CustomFilter("000327")]
        public async Task<ActionResult> ObtenerReporteGeneralGrafico(int IdSede, DateTime? Fdesde, DateTime? Fhasta)
        {
            try
            {
                var collection = await _clienteEncuestaApp.ObtenerReporteGrafico(IdSede, Fdesde, Fhasta);
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
