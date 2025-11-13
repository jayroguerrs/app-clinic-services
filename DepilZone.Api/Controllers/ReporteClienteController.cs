using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;
using DepilZone.Entidad.DTO;
using DepilZone.Application.Interface;
using Microsoft.AspNetCore.Authorization;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]

	public class ReporteClienteController : Controller
	{
		private readonly IReporteClienteApp _ReporteClienteApp;
		public ReporteClienteController(IReporteClienteApp IReporteClienteApp)
		{
			this._ReporteClienteApp = IReporteClienteApp;
		}

		[HttpGet("cumpleanio/{fechaDesde}/{fechaHasta}/{idEstadoAtendido}")]
		[CustomFilter("000426")]
		public async Task<ActionResult> ObtenerCumpleanios(DateTime fechaDesde, DateTime fechaHasta, int idEstadoAtendido)
		{
            try
            {
				List<ClienteCumpleaniosDTO> collection = await _ReporteClienteApp.ObtenerCumpleanios(fechaDesde, fechaHasta, idEstadoAtendido);
				return Ok(new
				{
					data = collection,
					message = "",
					status = StatusCodes.Status200OK
				});
            }
            catch (Exception e)
            {
				return Ok(new
				{
					data = new { },
					message = e.Message,
					status = StatusCodes.Status400BadRequest
				});
			}
			
		}

	}
}
