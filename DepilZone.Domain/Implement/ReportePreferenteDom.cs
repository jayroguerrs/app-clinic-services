using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Domain.Implement
{
	public class ReportePreferenteDom : IReportePreferenteDom
	{
		private readonly IReportePreferenteDat _IReportePreferenteDat;

		public ReportePreferenteDom(IReportePreferenteDat IReportePreferenteDat)
		{
			this._IReportePreferenteDat = IReportePreferenteDat;
		}
		public async Task<List<PreferenteReporteMedioContactoDTO>> ObtenerReportePorMedioContacto(DateTime fechaDesde, DateTime fechaHasta, int idMedioContacto)
		{
			return await _IReportePreferenteDat.ObtenerReportePorMedioContacto(fechaDesde, fechaHasta, idMedioContacto);
		}

		public async Task<PreferenteReporteTotalDTO> ObtenerReporteTotal(DateTime fecha)
		{
			return await _IReportePreferenteDat.ObtenerReporteTotal(fecha);
		}
	}
}
