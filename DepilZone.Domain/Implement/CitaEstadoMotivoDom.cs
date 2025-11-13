using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain.Implement
{
	public class CitaEstadoMotivoDom : ICitaEstadoMotivoDom
	{
		private readonly ICitaEstadoMotivoDat _ICitaEstadoMotivoDat;
		public CitaEstadoMotivoDom(ICitaEstadoMotivoDat ICitaEstadoMotivoDat)
		{
			this._ICitaEstadoMotivoDat = ICitaEstadoMotivoDat;
		}


		public async Task<List<CitaEstadoMotivoEnt>> Listar()
        {
			return await _ICitaEstadoMotivoDat.Listar();
		}
		public async Task<CitaEstadoMotivoEnt> Grabar(CitaEstadoMotivoDTO model)
        {
			return await _ICitaEstadoMotivoDat.Grabar(model);
		}

		public async Task<List<CitaEstadoMotivoRespuestaEnt>> ObtenerReporteGeneral(CitaEstado_ParametrosDTO input)
		{
			return await _ICitaEstadoMotivoDat.ObtenerReporteGeneral(input);
		}

	}
}
