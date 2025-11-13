using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain.Implement
{
	public class TurnoDom : ITurnoDom
	{
		private readonly ITurnoDat _ITurnoDat;
		public TurnoDom(ITurnoDat ITurnoDat)
		{
			this._ITurnoDat = ITurnoDat;
		}
		public async Task<IEnumerable<TurnoEnt>> Obtener()
		{
			return await _ITurnoDat.Obtener();
		}
		public async Task<TurnoEnt> ObtenerById(int IdTurno)
		{
			return await _ITurnoDat.ObtenerById(IdTurno);
		}
	}
}