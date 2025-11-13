using DepilZone.Api.CustomFilter;
using DepilZone.Application.Interface.C360;
using DepilZone.Entidad.DTO.C360;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers.C360
{
    [Route("api/c360/[controller]")]
    [ApiController]
    public class TipoClienteController : ControllerBase
    {

        private readonly ITipoClienteApp _TipoCliente;
        public TipoClienteController(ITipoClienteApp TipoClienteApp)
        {
            _TipoCliente = TipoClienteApp;
        }

        [HttpGet]
        [CustomFilter("000549")]
        public async Task<ActionResult> Listar()
        {
            try
            {
                var lista = await _TipoCliente.Listar();
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
        [HttpGet("estado/{idEstado}")]
        [CustomFilter("000550")]
        public async Task<ActionResult> ListarByEstado(int idEstado)
        {
            try
            {
                var lista = await _TipoCliente.ListarByEstado(idEstado);
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
        [CustomFilter("000551")]
        public async Task<ActionResult> Registrar(TipoCliente360DTO model)
        {

            try
            {
                await _TipoCliente.Registrar(model);
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
        [CustomFilter("000552")]
        public async Task<ActionResult> Modificar(int id, TipoCliente360DTO model)
        {
            try
            {
                await _TipoCliente.Modificar(id, model);
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
    }
}
