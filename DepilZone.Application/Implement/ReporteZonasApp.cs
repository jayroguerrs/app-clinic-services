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
	public class ReporteZonasApp : IReporteZonasApp
	{
        private readonly IReporteZonasDom _IReporteZonasDom;
        public ReporteZonasApp(IReporteZonasDom IReporteZonasDom)
        {
            this._IReporteZonasDom = IReporteZonasDom;
        }

        public async Task<IEnumerable<ReporteZonaDTO>> Obtener()
        {
            return await _IReporteZonasDom.Obtener();
        }
        public async Task<IEnumerable<ReporteZonaDTO>> Obtenerfecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            return await _IReporteZonasDom.Obtenerfecha(fechaInicio, fechaTermino);
        }
        public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimo()
        {
            return await _IReporteZonasDom.Obtenerminimo();
        }
        public async Task<IEnumerable<ReporteZonaDTO>> Obtenerminimofecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            return await _IReporteZonasDom.Obtenerminimofecha(fechaInicio, fechaTermino);
        }
        public async Task<IEnumerable<PleEnt>> Obtenerple(DateTime fechaInicio, DateTime fechaTermino)
        {
            return await _IReporteZonasDom.Obtenerple(fechaInicio, fechaTermino);
        }
        public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialista()
        {
            return await _IReporteZonasDom.Obtenerespecialista();
        }
        public async Task<IEnumerable<EspecialistasDTO>> Obtenerespecialistafecha(DateTime fechaInicio, DateTime fechaTermino)
        {
            return await _IReporteZonasDom.Obtenerespecialistafecha(fechaInicio, fechaTermino);
        }
        public async Task<IEnumerable<ReporteCitaDTO>> Obtenercitafecha(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IReporteZonasDom.Obtenercitafecha(fechaInicio, fechaTermino);
		}
		public async Task<IEnumerable<ReporteCitaDTO>> Obtenercita()
        {
            return await _IReporteZonasDom.Obtenercita();
        }
    }
}
