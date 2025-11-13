using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class ReporteCitaApp : IReporteCitaApp
	{
        private readonly IReporteCitaDom _IReporteCitaDom;
        public ReporteCitaApp(IReporteCitaDom IReporteCitaDom)
        {
            this._IReporteCitaDom = IReporteCitaDom;
        }

        public async Task<List<EspecialistaDTO>> ObtenerEspecialistasCitas(int idSede, DateTime fechaInicio, DateTime fechaTermino, int idUsuario)
        {
            return await _IReporteCitaDom.ObtenerEspecialistasCitas(idSede, fechaInicio, fechaTermino, idUsuario);
        }

        public async Task<List<EspecialistaCitaDTO>> ObtenerEspecialistasCitasDetalle(int idUsuario, DateTime fecha, int idSede)
        {
            return await _IReporteCitaDom.ObtenerEspecialistasCitasDetalle(idUsuario, fecha, idSede);
        }

        public async Task<List<CronogramaCitasAtendidasDTO>> ObtenerCronogramaCitasAtendidas(int idSede, DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _IReporteCitaDom.ObtenerCronogramaCitasAtendidas(idSede, fechaDesde, fechaHasta);
        }

        public async Task<List<ReporteAtendidosDiariosDTO>> ReporteAtendidosDiarios(DateTime fecha, int idSede, int idServicio)
        {
            return await _IReporteCitaDom.ReporteAtendidosDiarios(fecha, idSede, idServicio);
        }
    
    }
}
