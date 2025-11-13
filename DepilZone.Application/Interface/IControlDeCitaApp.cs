using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IControlDeCitaApp
    {
        Task<IEnumerable<ControlDeCitaDTO>> ObtenerDiezCitas();
        Task<ControlDeCitasByUserResponseDTO> ObtenerCitas(int IdUsuarioOperador, int Pagina, int RowsPerPage, DateTime? FechaInicio, DateTime? FechaFin, string? Busqueda, string? Pagado, string? Estado, int? MostrarPagadosMensual, int? MostrarAbonado, int? OcultarAnulados);
        Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateFinalPayment(int IdCita, decimal PrecioDePagoFinal, int idUsuario, int? TipoPago);
        Task<GeneralResponse<UpdateFinalPaymentDTO>> UpdateZonaFinalPayment(int IdDetalle, decimal PrecioNuevoDePagoFinal, int IdCita);
        Task<totalNotificaionPorSede> EnviarNotificaionDePago(int IdOperador, int IdTipoSede, string NombreOperador, int IdCita);
        Task<IEnumerable<Notificacion>> ListadoDeNotificaciones(int IdSede);
        Task<int> ObtenerTotalDeNotificaciones(int IdSede);
        Task<GeneralResponse<bool>> CompletarNotificacion(int IdNotificacion);
        Task<IEnumerable<ControlDeCitasByUserExcelDTO>> ObtenerCitasExcel(int IdUsuarioOperador, DateTime? FechaInicio, DateTime? FechaFin, int? OcultarAnulados, string? Estado);

    }
}
