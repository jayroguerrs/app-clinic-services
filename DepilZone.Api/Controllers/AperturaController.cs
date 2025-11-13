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

    public class AperturaController : Controller
	{
		private readonly IAperturaApp _apertura;
		public AperturaController(IAperturaApp AperturaApp)
		{
			this._apertura = AperturaApp;
		}
		[HttpPost]
		[CustomFilter("000186")]
		public async Task<Respuesta<ListadoAperturayCierreEnt>> Post(ListadoAperturayCierreEnt model)
		{
			return await _apertura.Insertar(model);
		}
		[HttpGet("listadoaperturaycierreporfechayidturno/{fechainicio}/{idturno}/{idcaja}")]
        [CustomFilter("000187")]
		public async Task<IEnumerable<ListadoAperturayCierreEnt>> Obtenerlistadoaperturaycierreporfechayidturno(DateTime fechaInicio, int idturno, int idcaja)
		{
			return await _apertura.Obtenerlistadoaperturaycierreporfechayidturno(fechaInicio, idturno, idcaja);
		}
		[HttpGet("reportecierre/{fechainicio}/{idturno}")]
        [CustomFilter("000188")]
		public async Task<IEnumerable<ReporteAperturaEnt>> reportecierre(DateTime fechaInicio, int idturno)
		{
			return await _apertura.reportecierre(fechaInicio, idturno);
		}
		[HttpGet("montototal/{fechainicio}/{idturno}")]
        [CustomFilter("000189")]
		public async Task<IEnumerable<ReporteAperturaEnt>> montototal(DateTime fechaInicio, int idturno)
		{
			return await _apertura.montototal(fechaInicio, idturno);
		}
		[HttpGet("principal/{fechainicio}/{idturno}/{idcaja}")]
        [CustomFilter("000190")]
		public async Task<IEnumerable<ReporteAperturaEnt>> principal(DateTime fechaInicio, int idturno, int idcaja)
		{
			return await _apertura.principal(fechaInicio, idturno, idcaja);
		}
		[HttpPut]
        [CustomFilter("000191")]
		public async Task<Respuesta<ListadoAperturayCierreEnt>> Put(ListadoAperturayCierreEnt model)
		{
			return await _apertura.Modificar(model);
		}
	}
}
