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
    public class TurnoController : Controller
	{
		private readonly ITurnoApp _turno;
		public TurnoController(ITurnoApp TurnoApp)
		{
			this._turno = TurnoApp;
		}
		[HttpGet("zxczdas")]
		[CustomFilter("000457")]
		public async Task<IEnumerable<TurnoEnt>> Get()
		{
			return await _turno.Obtener();
		}
		[HttpGet("{IdTurno}")]
        [CustomFilter("000458")]
		public async Task<TurnoEnt> Get(int IdTurno)
		{
			return await _turno.ObtenerById(IdTurno);
		}
	}
}

