using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Domain.Implement
{
	public class ReporteClienteDom : IReporteClienteDom
	{
		private readonly IReporteClienteDat _IReporteClienteDat;

		public ReporteClienteDom(IReporteClienteDat IReporteClienteDat)
		{
			this._IReporteClienteDat = IReporteClienteDat;
		}
		public async Task<List<ClienteCumpleaniosDTO>> ObtenerCumpleanios(DateTime fechaDesde, DateTime fechaHasta, int idEstadoAtendido)
		{
			return await _IReporteClienteDat.ObtenerCumpleanios(fechaDesde, fechaHasta, idEstadoAtendido);
		}
	}
}
