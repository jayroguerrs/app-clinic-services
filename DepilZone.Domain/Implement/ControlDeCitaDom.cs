using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class ControlDeCitaDom : IControlDeCitaDom
    {
        private readonly IControlDeCitaDat _ControlDeCitaDat;
        public ControlDeCitaDom(IControlDeCitaDat IControlDeCita)
        {
            this._ControlDeCitaDat = IControlDeCita;
        }

        public async Task<IEnumerable<ControlDeCitaDTO>> ObtenerDiezCitas() 
        {
            return await _ControlDeCitaDat.ObtenerDiezCitas();
        }

        public async Task<ControlDeCitasByUserResponseDTO> ObtenerCitas(int IdUsuarioOperador, int Pagina, int RowsPerPage, DateTime? FechaInicio, DateTime? FechaFin, string? Busqueda, string? Pagado, string? Estado, int? MostrarPagadosMensual, int? MostrarAbonado, int? OcultarAnulados)
        {
            return await _ControlDeCitaDat.ObtenerCitas(IdUsuarioOperador, Pagina, RowsPerPage, FechaInicio, FechaFin, Busqueda, Pagado, Estado, MostrarPagadosMensual, MostrarAbonado, OcultarAnulados);
        }

        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateFinalPayment(int IdCita, decimal PrecioDePagoFinal, int idUsuario, int? TipoPago)
        {
            return await _ControlDeCitaDat.UpdateFinalPayment(IdCita, PrecioDePagoFinal, idUsuario, TipoPago);
        }
        public async Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateZonaFinalPayment(int IdDetalle, decimal PrecioNuevoDePagoFinal, int IdCita)
        {
            return await _ControlDeCitaDat.UpdateZonaFinalPayment(IdDetalle, PrecioNuevoDePagoFinal, IdCita);
        }

        public async Task<totalNotificaionPorSede> EnviarNotificaionDePago(int IdOperador, int IdTipoSede, string NombreOperador, int IdCita)
        {
            return await _ControlDeCitaDat.EnviarNotificaionDePago(IdOperador, IdTipoSede, NombreOperador, IdCita);
        }
        public async Task<IEnumerable<Notificacion>> ListadoDeNotificaciones(int IdSede)
        {
            return await _ControlDeCitaDat.ListadoDeNotificaciones(IdSede);
        }
        public async Task<int> ObtenerTotalDeNotificaciones(int IdSede)
        {
            return await _ControlDeCitaDat.ObtenerTotalDeNotificaciones(IdSede);
        }
        public async Task<GeneralResponse<bool>> CompletarNotificacion(int IdNotificacion)
        {
            return await _ControlDeCitaDat.CompletarNotificacion(IdNotificacion);
        }

        public async Task<IEnumerable<ControlDeCitasByUserExcelDTO>> ObtenerCitasExcel(int IdUsuarioOperador, DateTime? FechaInicio, DateTime? FechaFin, int? OcultarAnulados, string? Estado)
        {
            return await _ControlDeCitaDat.ObtenerCitasExcel(IdUsuarioOperador, FechaInicio, FechaFin, OcultarAnulados, Estado);
        }

    }
}
