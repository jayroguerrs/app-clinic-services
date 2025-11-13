using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Data.Response;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/cliente-asignado-estado")]
    [ApiController]
    [Authorize]

    public class ClienteAsignadoEstadoController : ControllerBase
    {
        private readonly IClienteAsignadoEstadoApp _clienteAsignadoApp;

        public ClienteAsignadoEstadoController(IClienteAsignadoEstadoApp IClienteAsignadoEstadoApp)
        {
            _clienteAsignadoApp = IClienteAsignadoEstadoApp;
        }

        [HttpGet("listado")]
        [CustomFilter("000307")]
        public async Task<ActionResult> Listado()
        {
            try
            {
                var data = await _clienteAsignadoApp.Listado();
                return Ok(new JsonResponse()
                {
                    Data = data,
                    Error = null,
                    Status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new JsonResponse()
                {
                    Data = null,
                    Error = ex.Message,
                    Status = StatusCodes.Status400BadRequest
                });
            }
        }
    }   
}
