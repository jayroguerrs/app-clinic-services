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
	public class  EgresoApp : IEgresoApp
	{
		private readonly IEgresoDom _IEgresoDom;
		public EgresoApp(IEgresoDom IEgresoDom)
		{
			this._IEgresoDom = IEgresoDom;
		}
		public async Task<Respuesta<EgresoEnt>> Insertar(EgresoEnt model)
		{
			return await _IEgresoDom.Insertar(model);
		}
		public async Task<IEnumerable<EgresoDTO>> Obtener(DateTime fechaInicio, DateTime fechaTermino)
		{
			return await _IEgresoDom.Obtener(fechaInicio, fechaTermino);
		}
		public async Task<bool> AnularEgreso(EgresoEnt model)
		{
			return await _IEgresoDom.AnularEgreso(model);
		}
	}
}
