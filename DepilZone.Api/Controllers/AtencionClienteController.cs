using System;
using System.Threading.Tasks;
using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DepilZone.Api.Controllers
{
	[Route("api/atencion-cliente")]
	[ApiController]
    [Authorize]

    public class AtencionClienteController : Controller
	{
		private readonly IAtencionClienteApp _atencionCliente;
		public AtencionClienteController(IAtencionClienteApp AtencionClienteApp)
		{
			this._atencionCliente = AtencionClienteApp;
		}

		[HttpPost]
		[CustomFilter("000192")]
		public async Task<ActionResult> Registrar(AtencionClienteRegistrarDTO model)
		{
			try
			{
				bool respuesta = await _atencionCliente.Insertar(model);
				return Ok(new JsonResponse() {
					Data = respuesta,
					Error = null,
					Status = StatusCodes.Status201Created
				});
			}
            catch (AlertException e)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception e)
			{
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = e.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
		}
    }
}
