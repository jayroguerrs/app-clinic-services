using DepilZone.Api.Hubs;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using DepilZone.Api.CustomFilter;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
    [Authorize]

    public class ReporteZonasController : Controller
	{
		private readonly IReporteZonasApp _ReporteZonasApp;
		public ReporteZonasController(IReporteZonasApp IReporteZonasApp)
		{
			this._ReporteZonasApp = IReporteZonasApp;
		}

		[HttpGet("zxcasdas")]
		[CustomFilter("000429")]
		public async Task<IEnumerable<ReporteZonaDTO>> Get()
		{
			return await _ReporteZonasApp.Obtener();
		}
		[HttpGet("maximo/{fechainicio}/{fechaTermino}")]
		[CustomFilter("000430")]
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerfecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerfecha(fechaInicio, fechaTermino);
		}
		[HttpGet("minimo/")]
        [CustomFilter("000431")]
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimo()
		{
			return await _ReporteZonasApp.Obtenerminimo();
		}
		[HttpGet("minimo/{fechainicio}/{fechaTermino}")]
        [CustomFilter("000432")]
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimofecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerminimofecha(fechaInicio, fechaTermino);
		}
		[HttpGet("especialistas/")]
		[CustomFilter("000433")]
		public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialista()
		{
			return await _ReporteZonasApp.Obtenerespecialista();
		}
		[HttpGet("especialistas/{fechainicio}/{fechaTermino}")]
        [CustomFilter("000434")]
		public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialistafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerespecialistafecha(fechaInicio, fechaTermino);
		}
		[HttpGet("cita/")]
        [CustomFilter("000435")]
		public async Task<IEnumerable<ReporteCitaDTO>> Obtenercita()
		{
			return await _ReporteZonasApp.Obtenercita();
		}
		[HttpGet("cita/{fechainicio}/{fechaTermino}")]
        [CustomFilter("000436")]
		public async Task<IEnumerable<ReporteCitaDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenercitafecha(fechaInicio, fechaTermino);
		}
		[HttpGet("ple/{fechainicio}/{fechaTermino}")]
        [CustomFilter("000437")]
		public async Task<IEnumerable<PleEnt>> Obtenerple(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ReporteZonasApp.Obtenerple(fechaInicio, fechaTermino);
		}
	}
}
