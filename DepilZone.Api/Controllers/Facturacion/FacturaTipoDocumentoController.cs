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
    public class FacturaTipoDocumentoController : ControllerBase
    {

        private readonly IFacturaTipoDocumentoApp _tipoDocumentoApp;
        public FacturaTipoDocumentoController(IFacturaTipoDocumentoApp FacturaTipoDocumentoApp)
        {
            _tipoDocumentoApp = FacturaTipoDocumentoApp;
        }

        [HttpGet("lista/{idUsuario}")]
        public async Task<ActionResult> Listar(int IdUsuario)
        {
            try
            {
                var lista = await _tipoDocumentoApp.Listar(IdUsuario);
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
                var lista = await _tipoDocumentoApp.Listar2(IdUsuario);
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
        public async Task<ActionResult> Registrar(FacturaTipoDocumentoDTO model)
        {

            try
            {
                await _tipoDocumentoApp.Registrar(model);
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
        public async Task<ActionResult> Modificar(int id, FacturaTipoDocumentoDTO model)
        {
            try
            {
                await _tipoDocumentoApp.Modificar(id, model);
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
                var data = await _tipoDocumentoApp.Buscar(id,idUsuario);
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
