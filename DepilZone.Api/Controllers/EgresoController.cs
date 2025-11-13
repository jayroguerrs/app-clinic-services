using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]

	public class EgresoController : Controller
	{
		private readonly IEgresoApp _egreso;
		public EgresoController(IEgresoApp EgresoApp)
		{
			this._egreso = EgresoApp;
		}
		[HttpPost]
		[CustomFilter("000372")]
		public async Task<Respuesta<EgresoEnt>> Post(EgresoEnt model)
		{
			return await _egreso.Insertar(model);
		}
		[HttpGet("listado/{fechainicio}/{fechaTermino}")]
        [CustomFilter("000373")]
        public async Task<IEnumerable<EgresoDTO>> Obtener(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _egreso.Obtener(fechaInicio, fechaTermino);
		}
		[HttpPut("anularEgreso")]
        [CustomFilter("000374")]
        public async Task<bool> AnularEgreso(EgresoEnt model)
		{
			return await _egreso.AnularEgreso(model);
		}
	}
}
