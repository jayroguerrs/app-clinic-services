using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]

	public class ClienteIncidenciaController : Controller
	{
		private readonly IClienteIncidenciaApp _ClienteIncidencia;
		public ClienteIncidenciaController(IClienteIncidenciaApp ClienteIncidenciaApp)
		{
			this._ClienteIncidencia = ClienteIncidenciaApp;
		}

		[HttpGet("{idSede}/{fechaDesde}/{fechaHasta}")]
		[CustomFilter("000328")]
		public async Task<ActionResult> Listar(int idSede, DateTime fechaDesde, DateTime fechaHasta)
		{
            try
            {
				var data = await _ClienteIncidencia.Listar(idSede, fechaDesde, fechaHasta);
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
					data = new{},
					message = e.Message,
					status = StatusCodes.Status400BadRequest
				});
            }
		}
		[HttpGet("cliente/{idCliente}")]
        [CustomFilter("000329")]
        public async Task<ActionResult> ListarPorCliente(int idCliente)
		{
			try
			{
				var data = await _ClienteIncidencia.ListarPorCliente(idCliente);
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
		[HttpPost]
        [CustomFilter("000330")]
        public async Task<ActionResult> Registrar(ClienteIncidenciaDTO model)
		{
			try
			{
				var data = await _ClienteIncidencia.Registrar(model);
				return Ok(new
				{
					data = data,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
			catch (AlertException e)
			{
				return BadRequest(new
				{
					data = new { },
					message = e.Message,
					status = StatusCodes.Status400BadRequest
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
