using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class ClienteAccesoController : ControllerBase
    {
        private readonly IClienteAccesoApp _ClienteAcceso;
        public ClienteAccesoController(IClienteAccesoApp ClienteAccesoApp)
        {
            _ClienteAcceso = ClienteAccesoApp;
        }

        [HttpPut("{idCliente}/correo")]
        [CustomFilter("000295")]
        public async Task<ActionResult> ModificarCorreo(int idCliente, ClienteAccesoDTO model)
        {
            try
            {
                await _ClienteAcceso.ModificarCorreo(idCliente, model);
                return Ok(new
                {
                    data = new {},
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch(AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
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
        [HttpPut("{idCliente}/clave")]
        [CustomFilter("000296")]
        public async Task<ActionResult> ModificarClave(int idCliente, ClienteAccesoDTO model)
        {
            try
            {
                await _ClienteAcceso.ModificarClave(idCliente, model);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
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
        [HttpGet("{idCliente}/credenciales")]
        [CustomFilter("000297")]
        public async Task<ActionResult> ObtenerCredenciales(int idCliente)
        {
            try
            {
                ClienteAccesoDTO output = await _ClienteAcceso.ObtenerCredenciales(idCliente);
                return Ok(new
                {
                    data = output,
                    message = "",
                    status = StatusCodes.Status200OK
                });
            }
            catch (AlertException ex)
            {
                return Ok(new
                {
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
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