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

	public class FormularioEncuestaController : Controller
	{
		private readonly IFormularioEncuestaApp _formularioEncuesta;
		public FormularioEncuestaController(IFormularioEncuestaApp FormularioEncuestaApp)
		{
			this._formularioEncuesta = FormularioEncuestaApp;
		}

		[HttpGet("tipo/{idTipo}")]
		[CustomFilter("000177")]
		public async Task<ActionResult> ObtenerListado(int idTipo)
		{
            try
            {
				var collection = await _formularioEncuesta.ObtenerListado(idTipo);
				return Ok(new {
					data = collection,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
            catch (Exception ex)
            {
				return BadRequest(new
				{
					data = new { },
					message = ex.Message,
					status = StatusCodes.Status400BadRequest
				});
            }
		}
		[HttpGet("cliente/{idCliente}/{idTipo}")]
        [CustomFilter("000178")]
		public async Task<ActionResult> ObtenerListado(int idCliente,int idTipo)
		{
			try
			{
				var collection = await _formularioEncuesta.ObtenerListadoByCliente(idCliente,idTipo);
				return Ok(new
				{
					data = collection,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
			catch (Exception ex)
			{
				return BadRequest(new
				{
					data = new { },
					message = ex.Message,
					status = StatusCodes.Status400BadRequest
				});
			}
		}
		[HttpGet("{id}")]
        [CustomFilter("000179")]
		public async Task<ActionResult> obtenerById(int id)
		{
			try
			{
				var data = await _formularioEncuesta.ObtenerById(id);
				return Ok(new
				{
					data = data,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
			catch (Exception)
			{
				return BadRequest(new
				{
					data = new { },
					message = "",
					status = StatusCodes.Status400BadRequest
				});
			}
		}
		[HttpPost]
        [CustomFilter("000180")]
		public async Task<ActionResult> guardarEncuesta(FormularioEncuestaRespuestaDTO model)
		{
			try
			{
				var data = await _formularioEncuesta.GuardarEncuesta(model);
				return Ok(new
				{
					data = data,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
			catch (Exception)
			{
				return BadRequest(new
				{
					data = new { },
					message = "",
					status = StatusCodes.Status400BadRequest
				});
			}
		}
		[HttpGet("reporte/{idSede}/{idFormulario}/{fechaInicio}/{fechaFin}")]
        [CustomFilter("000181")]
		public async Task<ActionResult> obtenerReporte(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
		{
			try
			{
				var data = await _formularioEncuesta.ObtenerReporte(idSede, idFormulario, fechaInicio, fechaFin);
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
		[HttpGet("buscar/{idFormulario}")]
        [CustomFilter("000182")]
		public async Task<ActionResult> buscarFormulario( int idFormulario)
		{
			try
			{
				var data = await _formularioEncuesta.BuscarReporte(idFormulario);
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
		[HttpGet("clientes/{idSede}/{idFormulario}/{fechaInicio}/{fechaFin}")]
        [CustomFilter("000183")]
		public async Task<ActionResult> ObtenerClientes(int idSede, int idFormulario, DateTime fechaInicio, DateTime fechaFin)
		{
			try
			{
				var data = await _formularioEncuesta.ObtenerClientes(idSede, idFormulario, fechaInicio, fechaFin);
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
		[HttpGet("buscar/{idCliente}/{idFormulario}")]
        [CustomFilter("000184")]
		public async Task<ActionResult> ObtenerListadoByClienteFormulario(int idCliente, int idFormulario)
		{
			try
			{
				var collection = await _formularioEncuesta.ObtenerListadoByClienteFormulario(idCliente, idFormulario);
				return Ok(new
				{
					data = collection,
					message = "",
					status = StatusCodes.Status200OK
				});
			}
			catch (Exception ex)
			{
				return BadRequest(new
				{
					data = new { },
					message = ex.Message,
					status = StatusCodes.Status400BadRequest
				});
			}
		}
	}
}
