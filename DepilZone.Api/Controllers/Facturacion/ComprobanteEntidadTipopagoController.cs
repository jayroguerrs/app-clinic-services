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
    public class ComprobanteEntidadTipoPagoController : ControllerBase
    {

        private readonly IComprobanteEntidadTipoPagoApp _ComprobanteEntidadTipoPago;
        public ComprobanteEntidadTipoPagoController(IComprobanteEntidadTipoPagoApp ComprobanteEntidadTipoPagoApp)
        {
            _ComprobanteEntidadTipoPago = ComprobanteEntidadTipoPagoApp;
        }

        [HttpGet("lista/{idUsuario}")]
        public async Task<ActionResult> Listar(int IdUsuario)
        {
            try
            {
                var lista = await _ComprobanteEntidadTipoPago.Listar(IdUsuario);
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



    }
}
