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

    public class ClienteRecurrenteController : Controller
	{

		private readonly IClienteRecurrenteApp _ClienteRecurrenteApp;
		public ClienteRecurrenteController(IClienteRecurrenteApp IClienteRecurrenteApp)
		{
			this._ClienteRecurrenteApp = IClienteRecurrenteApp;
		}

        [HttpGet("GETSDA")]
		[CustomFilter("000331")]
        public async Task<IEnumerable<ClienteRecurrenteDTO>> Get()
		{
			return await _ClienteRecurrenteApp.Obtener();
		}
		[HttpGet("cita/{fechainicio}/{fechaTermino}")]
		[CustomFilter("000332")]
		public async Task<IEnumerable<ClienteRecurrenteDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _ClienteRecurrenteApp.Obtenercitafecha(fechaInicio, fechaTermino);
		}
	}
}
