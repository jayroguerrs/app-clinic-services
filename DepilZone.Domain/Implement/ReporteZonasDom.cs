using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Domain.Implement
{
	public class ReporteZonasDom : IReporteZonasDom
	{
		private readonly IReporteZonasDat _IReporteZonasDat;

		public ReporteZonasDom(IReporteZonasDat IReporteZonasDat)
		{
			this._IReporteZonasDat = IReporteZonasDat;
		}
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerfecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IReporteZonasDat.Obtenerfecha(fechaInicio, fechaTermino);
		}
		public async Task<IEnumerable<ReporteZonaDTO>> Obtener()
		{
			return await _IReporteZonasDat.Obtener();
		}
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimo()
		{
			return await _IReporteZonasDat.Obtenerminimo();
		}
		public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimofecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IReporteZonasDat.Obtenerminimofecha(fechaInicio, fechaTermino);
		}
		public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialista()
		{
			return await _IReporteZonasDat.Obtenerespecialista();
		}
		public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialistafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IReporteZonasDat.Obtenerespecialistafecha(fechaInicio, fechaTermino);
		}
		public async Task<IEnumerable<ReporteCitaDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IReporteZonasDat.Obtenercitafecha(fechaInicio, fechaTermino);
		}
		public async Task<IEnumerable<ReporteCitaDTO>> Obtenercita()
		{
			return await _IReporteZonasDat.Obtenercita();
		}
		public async Task<IEnumerable<PleEnt>> Obtenerple(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IReporteZonasDat.Obtenerple(fechaInicio, fechaTermino);
		}
	}
}
