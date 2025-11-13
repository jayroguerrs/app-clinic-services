using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IReportePreferenteDat
	{
		Task<List<PreferenteReporteMedioContactoDTO>> ObtenerReportePorMedioContacto(DateTime fechaDesde, DateTime fechaHasta, int idMedioContacto);
		Task<PreferenteReporteTotalDTO> ObtenerReporteTotal(DateTime fecha);
	}
}
