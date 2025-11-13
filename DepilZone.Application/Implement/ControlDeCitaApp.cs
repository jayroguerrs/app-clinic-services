using DepilZone.Application.Interface;
using DepilZone.Data.Implement;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ControlDeCitaApp : IControlDeCitaApp
    {
        private readonly IControlDeCitaDom _ControlDeCitaDom;
        public ControlDeCitaApp(IControlDeCitaDom IControlDeCitaDom)
        {
            this._ControlDeCitaDom = IControlDeCitaDom;
        }

        public async Task<IEnumerable<ControlDeCitaDTO>> ObtenerDiezCitas()
        {
            return await _ControlDeCitaDom.ObtenerDiezCitas();
        }

        public async Task<ControlDeCitasByUserResponseDTO> ObtenerCitas(int IdUsuarioOperador, int Pagina, int RowsPerPage, DateTime? FechaInicio, DateTime?  FechaFin, string? Busqueda, string? Pagado, string? Estado, int? MostrarPagadosMensual, int? MostrarAbonado, int? OcultarAnulados)
        {
            return await _ControlDeCitaDom.ObtenerCitas(IdUsuarioOperador,Pagina,RowsPerPage, FechaInicio, FechaFin, Busqueda, Pagado, Estado, MostrarPagadosMensual, MostrarAbonado, OcultarAnulados);
        }

        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateFinalPayment(int IdCita, decimal PrecioDePagoFinal, int idUsuario, int? TipoPago)
        {
            return await _ControlDeCitaDom.UpdateFinalPayment(IdCita, PrecioDePagoFinal, idUsuario, TipoPago);
        }

        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateZonaFinalPayment(int IdDetalle, decimal PrecioNuevoDePagoFinal, int IdCita)
        {
            return await _ControlDeCitaDom.UpdateZonaFinalPayment(IdDetalle, PrecioNuevoDePagoFinal, IdCita);
        }
        public async Task<totalNotificaionPorSede> EnviarNotificaionDePago(int IdOperador, int IdTipoSede, string NombreOperador, int IdCita)
        {
            return await _ControlDeCitaDom.EnviarNotificaionDePago(IdOperador, IdTipoSede, NombreOperador, IdCita);
        }
        public async Task<IEnumerable<Notificacion>> ListadoDeNotificaciones(int IdSede)
        {
            return await _ControlDeCitaDom.ListadoDeNotificaciones(IdSede);
        }
        public async Task<int> ObtenerTotalDeNotificaciones(int IdSede)
        {
            return await _ControlDeCitaDom.ObtenerTotalDeNotificaciones(IdSede);
        }
        public async Task<GeneralResponse<bool>> CompletarNotificacion(int IdNotificacion)
        {
            return await _ControlDeCitaDom.CompletarNotificacion(IdNotificacion);
        }
        public async Task<IEnumerable<ControlDeCitasByUserExcelDTO>> ObtenerCitasExcel(int IdUsuarioOperador, DateTime? FechaInicio, DateTime? FechaFin, int? OcultarAnulados, string? Estado)
        {
            return await _ControlDeCitaDom.ObtenerCitasExcel(IdUsuarioOperador, FechaInicio, FechaFin, OcultarAnulados, Estado);
        }
    }
}
