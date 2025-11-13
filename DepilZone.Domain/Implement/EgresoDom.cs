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
	public class EgresoDom : IEgresoDom
	{
		private readonly IEgresoDat _IEgresoDat;
		public EgresoDom(IEgresoDat IEgresoDat)
		{
			this._IEgresoDat = IEgresoDat;
		}
		public async Task<Respuesta<EgresoEnt>> Insertar(EgresoEnt model)
		{
			return await _IEgresoDat.Insertar(model);
		}
		public async Task<IEnumerable<EgresoDTO>> Obtener(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IEgresoDat.Obtener(fechaInicio, fechaTermino);
		}
		public async Task<bool> AnularEgreso(EgresoEnt model)
		{
			return await _IEgresoDat.AnularEgreso(model);
		}
	}
}
