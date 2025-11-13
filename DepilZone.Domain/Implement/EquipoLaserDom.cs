using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;

namespace DepilZone.Domain.Implement
{
	public class EquipoLaserDom : IEquipoLaserDom
	{
		private readonly IEquipoLaserDat _IEquipoLaserDat;
		public EquipoLaserDom(IEquipoLaserDat IEquipoLaserDat)
		{
			this._IEquipoLaserDat = IEquipoLaserDat;
		}

		public async Task<IEnumerable<EquipoLaserEnt>> Obtener()
		{
			return await _IEquipoLaserDat.Obtener();
		}
	}
}
