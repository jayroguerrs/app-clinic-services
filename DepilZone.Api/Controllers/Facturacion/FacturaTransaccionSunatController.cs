using DepilZone.Application.Interface.Facturacion;
using DepilZone.Entidad.DTO.Facturacion;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers.Facturacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaTransaccionSunatController : ControllerBase
    {

        private readonly IFacturaTransaccionSunatApp _TransaccionSunatApp;
        public FacturaTransaccionSunatController(IFacturaTransaccionSunatApp FacturaTransaccionSunatApp)
        {
            _TransaccionSunatApp = FacturaTransaccionSunatApp;
        }

        [HttpGet("lista/{idUsuario}")]
        public async Task<ActionResult> Listar(int IdUsuario)
        {
            try
            {
                var lista = await _TransaccionSunatApp.Listar(IdUsuario);
                return Ok(new
                {
                    data = lista,
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
                return BadRequest(new { 
                    data = new { },
                    message = ex.Message,
                    status = StatusCodes.Status400BadRequest
                });
            }
        }


        [HttpGet("lista2/{idUsuario}")]
        public async Task<ActionResult> Listar2(int IdUsuario)
        {
            try
            {
                var lista = await _TransaccionSunatApp.Listar2(IdUsuario);
                return Ok(new
                {
                    data = lista,
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


        [HttpPost]
        public async Task<ActionResult> Registrar(FacturaTransaccionSunatDTO model)
        {

            try
            {
                await _TransaccionSunatApp.Registrar(model);
                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status201Created
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

        [HttpPut("{id}")]
        public async Task<ActionResult> Modificar(int id, FacturaTransaccionSunatDTO model)
        {
            try
            {
                await _TransaccionSunatApp.Modificar(id, model);
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


        [HttpGet("{id}/{idUsuario}")]
        public async Task<ActionResult> Buscar(int id, int idUsuario)
        {
            try
            {
                var data = await _TransaccionSunatApp.Buscar(id,idUsuario);
                return Ok(new
                {
                    data = data,
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
