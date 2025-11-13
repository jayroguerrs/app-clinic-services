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

    public class DescuentoController : Controller
	{
		private readonly IDescuentoApp _descuento;
		public DescuentoController(IDescuentoApp DescuentoApp)
		{
			this._descuento = DescuentoApp;
		}

		[HttpGet]
		[CustomFilter("000347")]
		public async Task<ActionResult> Get()
		{
            try
            {
				var data = await this._descuento.ObtenerListado();
				return Ok(new
				{
					data = data,
					message = "",
					status = StatusCodes.Status200OK
				});
            }
            catch (Exception ex)
            {
                //throw ex;
				return BadRequest(new {
					data = new { },
					message = ex.Message,
					status = StatusCodes.Status400BadRequest
				});
            }
		}
	}
}
