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
	public class CitaMotivoDom : ICitaMotivoDom
	{
		private readonly ICitaMotivoDat _ICitaMotivoDat;
		public CitaMotivoDom(ICitaMotivoDat ICitaMotivoDat)
		{
			this._ICitaMotivoDat = ICitaMotivoDat;
		}


		public async Task<List<CitaMotivoEnt>> ListarByCitaEstado( int idCitaEstado )
        {
			return await _ICitaMotivoDat.ListarByCitaEstado(idCitaEstado);
		}

		public async Task<List<CitaMotivoEnt>> Listar()
		{
			return await _ICitaMotivoDat.Listar();
		}

	}
}
