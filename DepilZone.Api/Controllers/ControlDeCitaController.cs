using DepilZone.Api.CustomFilter;
using DepilZone.Api.Services;
using DepilZone.Application.Interface;
using DepilZone.Entidad.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DepilZone.Data.Helpers;
using DepilZone.Entidad;
using Microsoft.AspNetCore.SignalR;
using DepilZone.Api.Hubs;
using System.Text.Json;


namespace DepilZone.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ControlDeCitaController : ControllerBase
    {
        private readonly IHubContext<SignalHub> _hubContext;
        private readonly IControlDeCitaApp _ControlDeCitaApp;
        public ControlDeCitaController(IControlDeCitaApp ControlDeCitaApp, IHubContext<SignalHub> hubContext)
        {
            this._ControlDeCitaApp = ControlDeCitaApp;
            _hubContext = hubContext;
        }

        [HttpGet("listadoControl")]
        public async Task<IEnumerable<ControlDeCitaDTO>> ObtenerListadoGrilla()
        {
            return await _ControlDeCitaApp.ObtenerDiezCitas();
        }

        [HttpGet("listadoControlByUser/{IdUsuarioOperador}/{Pagina}/{RowsPerPage}")]
        //[CustomFilter("000557")]
        public async Task<ControlDeCitasByUserResponseDTO> ObtenerListadoCitas(int IdUsuarioOperador, int Pagina, int RowsPerPage, [FromQuery] DateTime? FechaInicio, [FromQuery] DateTime? FechaFin, [FromQuery] string? Busqueda, [FromQuery] string? Pagado, [FromQuery] string? Estado, [FromQuery] int? MostrarPagadosMensual, [FromQuery] int? MostrarAbonado, [FromQuery] int? OcultarAnulados)
        {
            return await _ControlDeCitaApp.ObtenerCitas(IdUsuarioOperador, Pagina, RowsPerPage, FechaInicio, FechaFin, Busqueda, Pagado, Estado, MostrarPagadosMensual, MostrarAbonado, OcultarAnulados);
        }

        [HttpGet("listadoControlByUserExcel/{IdUsuarioOperador}")]
        public async Task<IEnumerable<ControlDeCitasByUserExcelDTO>> ObtenerListadoCitasExcel(int IdUsuarioOperador, [FromQuery] DateTime? FechaInicio, [FromQuery] DateTime? FechaFin, [FromQuery] int? OcultarAnulados, [FromQuery] string? Estado)
        {
            return await _ControlDeCitaApp.ObtenerCitasExcel(IdUsuarioOperador, FechaInicio, FechaFin, OcultarAnulados, Estado);
        }

        [HttpGet("listadoDeNotificaciones/{IdSede}")]
        public async Task<IEnumerable<Notificacion>> ListadoDeNotificaciones(int IdSede)
        {
            return await _ControlDeCitaApp.ListadoDeNotificaciones(IdSede);
        }

        [HttpGet("numeroTotalDeNotificaciones/{IdSede}")]
        public async Task<int> ObtenerTotalDeNotificaciones(int IdSede)
        {
            return await _ControlDeCitaApp.ObtenerTotalDeNotificaciones(IdSede);
        }


        [HttpPatch("changeFinalPayment/{IdCita}/{MontoFinal}/{idUsuario}")]
        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateFinalPayment(int IdCita, decimal MontoFinal, int idUsuario, [FromQuery] int? TipoDePago)
        {

            var result = await _ControlDeCitaApp.UpdateFinalPayment(IdCita, MontoFinal, idUsuario, TipoDePago);
            MensajeSignalR mensajeSignalR = new MensajeSignalR()
            {
                Exito = true,
                Mensaje = TipoAlerta.CitaPagada.ToString(),
                DatosJSON = JsonSerializer.Serialize(result),
                Tipo = TipoAlerta.CitaPagada
            };

            await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

            return result;

        }

        [HttpPatch("completarNotificacion/{IdNotificacion}")]
        public async Task<GeneralResponse<bool>> CompletarNotificacion(int IdNotificacion)
        {

            var result = await _ControlDeCitaApp.CompletarNotificacion(IdNotificacion);

            MensajeSignalR mensajeSignalR = new MensajeSignalR()
            {
                Exito = true,
                Mensaje = TipoAlerta.CitaPagada.ToString(),
                DatosJSON = JsonSerializer.Serialize(result),
                Tipo = TipoAlerta.CitaPagada
            };

            await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

            return result;

        }

        [HttpPatch("changeZonaFinalPayment/{IdDetalle}/{PrecioNuevoDePagoFinal}/{IdCita}")]
        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateZonaFinalPayment(int IdDetalle, decimal PrecioNuevoDePagoFinal, int IdCita)
        {

            var result = await _ControlDeCitaApp.UpdateZonaFinalPayment(IdDetalle, PrecioNuevoDePagoFinal, IdCita);
            return result;

        }

        [HttpPost("enviarNotificacionDePago/{IdOperador}/{IdTipoSede}/{NombreOperador}/{IdCita}")]
        public async Task<ActionResult> EnviarNotificaionDePago(int IdOperador, int IdTipoSede, string NombreOperador, int IdCita)
        {
            try
            {
                totalNotificaionPorSede totalDeNotificaciones = await _ControlDeCitaApp.EnviarNotificaionDePago(IdOperador, IdTipoSede, NombreOperador, IdCita);

                MensajeSignalR mensajeSignalR = new MensajeSignalR()
                {
                    Exito = true,
                    Mensaje = TipoAlerta.NotificacionDePago.ToString(),
                    DatosJSON = JsonSerializer.Serialize(totalDeNotificaciones),
                    Tipo = TipoAlerta.NotificacionDePago
                };

                await _hubContext.Clients.All.SendAsync("mensajeroSignal", mensajeSignalR);

                return Ok(new
                {
                    data = new { },
                    message = "",
                    status = StatusCodes.Status201Created
                });

            }
            catch (SystemException ex)
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
