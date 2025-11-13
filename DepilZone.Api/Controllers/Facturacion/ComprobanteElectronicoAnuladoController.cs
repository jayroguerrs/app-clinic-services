using DepilZone.Application.Interface.Facturacion;
using DepilZone.Entidad;
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
    public class ComprobanteElectronicoAnuladoController : ControllerBase
    {

        private readonly IComprobanteElectronicoAnuladoApp _IComprobanteElectronicoAnuladoAp;
        public ComprobanteElectronicoAnuladoController(IComprobanteElectronicoAnuladoApp ComprobanteElectronicoAnuladoApp)
        {
            _IComprobanteElectronicoAnuladoAp = ComprobanteElectronicoAnuladoApp;

        }


        [HttpGet("venta/{idVenta}/{idUsuario}")]
        public async Task<ActionResult> BuscarPorVenta(int idVenta, int idUsuario)
        {

            try
            {

                ComprobanteElectronicoMotivoAnuladoDTO d = await _IComprobanteElectronicoAnuladoAp.BuscarPorComprobante(idVenta, idUsuario);

                return Ok(new
                {
                    data = d,
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
