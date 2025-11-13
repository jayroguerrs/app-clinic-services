using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
	public interface IReporteZonasDat
	{
		Task<IEnumerable<ReporteZonaDTO>> Obtener();
		Task<IEnumerable<ReporteZonaDTO>> Obtenerfecha(DateTime fechaInicio, DateTime fechaTermino);
		Task<IEnumerable<ReporteZonaDTO>> Obtenerminimo();
		Task<IEnumerable<ReporteZonaDTO>> Obtenerminimofecha(DateTime fechaInicio, DateTime fechaTermino);
		Task<IEnumerable<PleEnt>> Obtenerple(DateTime fechaInicio, DateTime fechaTermino);
		Task<IEnumerable<EspecialistasDTO>> Obtenerespecialista();
		Task<IEnumerable<EspecialistasDTO>> Obtenerespecialistafecha(DateTime fechaInicio, DateTime fechaTermino);
		Task<IEnumerable<ReporteCitaDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino);
		Task<IEnumerable<ReporteCitaDTO>> Obtenercita();
	}
}
