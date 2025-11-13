
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
    public class FacturacionElectronicaController : ControllerBase
    {

        private readonly IFacturacionElectronicaApp _FacturacionElectronica;
        public FacturacionElectronicaController(IFacturacionElectronicaApp FacturacionElectronicaApp)
        {
            _FacturacionElectronica = FacturacionElectronicaApp;
        }

        [HttpGet("datos-comprobante-cita/{idCita}/{idUsuario}")]
        public async Task<ActionResult> ObtenerDatosComprobanteCita(int idCita, int idUsuario)
        {
            try
            {
                var lista = await _FacturacionElectronica.ObtenerDatosComprobanteCita(idCita, idUsuario);
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


        [HttpGet("datos-comprobante-cita-detalle/{idCita}/{idUsuario}")]
        public async Task<ActionResult> ObtenerCitaDetalleComprobanteCita(int idCita, int idUsuario)
        {
            try
            {
                var lista = await _FacturacionElectronica.ObtenerCitaDetalleComprobanteCita(idCita, idUsuario);
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


    }
}
