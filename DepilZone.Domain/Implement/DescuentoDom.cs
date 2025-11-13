using DepilZone.Data.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class DescuentoDom: IDescuentoDom
	{
		private readonly IDescuentoDat _IDescuentoDat;
		public DescuentoDom(IDescuentoDat IDescuentoDat)
		{
			this._IDescuentoDat = IDescuentoDat;
		}
		public async Task<List<DescuentoDTO>> ObtenerListado()
		{
			return await _IDescuentoDat.ObtenerListado();
		}
    }
}
