using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Domain.Implement
{
	public class ReporteCitaDom : IReporteCitaDom
	{
		private readonly IReporteCitaDat _IReporteCitaDat;

		public ReporteCitaDom(IReporteCitaDat IReporteCitaDat)
		{
			this._IReporteCitaDat = IReporteCitaDat;
		}
		public async Task<List<EspecialistaDTO>> ObtenerEspecialistasCitas(int idSede, DateTime fechaInicio, DateTime fechaTermino, int idUsuario)
		{
			return await _IReporteCitaDat.ObtenerEspecialistasCitas(idSede, fechaInicio, fechaTermino, idUsuario);
		}

		public async Task<List<EspecialistaCitaDTO>> ObtenerEspecialistasCitasDetalle(int idUsuario, DateTime fecha, int idSede)
        {
			return await _IReporteCitaDat.ObtenerEspecialistasCitasDetalle( idUsuario,  fecha, idSede);

		}

		public async Task<List<CronogramaCitasAtendidasDTO>> ObtenerCronogramaCitasAtendidas(int idSede, DateTime fechaDesde, DateTime fechaHasta)
        {
			return await _IReporteCitaDat.ObtenerCronogramaCitasAtendidas(idSede, fechaDesde, fechaHasta);
		}

		public async Task<List<ReporteAtendidosDiariosDTO>> ReporteAtendidosDiarios(DateTime fecha, int idSede, int idServicio)
        {
			return await _IReporteCitaDat.ReporteAtendidosDiarios(fecha, idSede, idServicio);
		}
	}
}
