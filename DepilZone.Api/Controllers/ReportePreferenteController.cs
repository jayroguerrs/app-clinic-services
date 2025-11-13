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

	public class ReportePreferenteController : Controller
	{
		private readonly IReportePreferenteApp _ReportePreferenteApp;
		public ReportePreferenteController(IReportePreferenteApp IReportePreferenteApp)
		{
			this._ReportePreferenteApp = IReportePreferenteApp;
		}

		[HttpGet("mediocontacto/{fechaDesde}/{fechaHasta}/{idMedioContacto}")]
		[CustomFilter("000427")]
		public async Task<ActionResult> ObtenerReportePorMedioContacto(DateTime fechaDesde, DateTime fechaHasta, int idMedioContacto)
		{
            try
            {
				List<PreferenteReporteMedioContactoDTO> collection = await _ReportePreferenteApp.ObtenerReportePorMedioContacto(fechaDesde, fechaHasta, idMedioContacto);
				return Ok(new
				{
					data = collection,
					message = "",
					status = StatusCodes.Status200OK
				});
            }
            catch (Exception e)
            {
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = StatusCodes.Status400BadRequest
				});
			}
			
		}
		[HttpGet("reporteTotal/{fecha}")]
		[CustomFilter("000428")]
		public async Task<ActionResult> ObtenerReporteTotal(DateTime fecha)
		{
			try
			{
				PreferenteReporteTotalDTO data = await _ReportePreferenteApp.ObtenerReporteTotal(fecha);
				return Ok(new
				{
					data = data,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
			catch (Exception e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = StatusCodes.Status400BadRequest
				});
			}

		}
	}
}
