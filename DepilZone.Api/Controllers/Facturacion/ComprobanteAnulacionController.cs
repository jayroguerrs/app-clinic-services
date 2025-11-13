using DepilZone.Application.Interface.Facturacion;
using DepilZone.Entidad.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DepilZone.Api.Controllers.Facturacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComprobanteAnulacionController : ControllerBase
    {

        private readonly IComprobanteAnulacionApp _ComprobanteAnulacion;
        public ComprobanteAnulacionController(IComprobanteAnulacionApp ComprobanteAnulacionApp)
        {
            _ComprobanteAnulacion = ComprobanteAnulacionApp;
        }

        [HttpGet("obtener/{fechaDesde}/{fechaHasta}/{idTipoComprobante}/{idSede}/{idUsuario}")]
        public async Task<ActionResult> Obtener(DateTime fechaDesde, DateTime fechaHasta, int idTipoComprobante,int idSede, int idUsuario)
        {
            try
            {
                var lista = await _ComprobanteAnulacion.Obtener( fechaDesde,  fechaHasta,  idTipoComprobante,  idSede,  idUsuario);
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
