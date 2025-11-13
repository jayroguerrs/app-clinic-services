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
	public class DescuentoApp : IDescuentoApp
	{
		private readonly IDescuentoDom _IDescuentoDom;
        public DescuentoApp(IDescuentoDom IDescuentoDom)
        {
            this._IDescuentoDom = IDescuentoDom;
        }

        public async Task<List<DescuentoDTO>> ObtenerListado()
        {
            return await _IDescuentoDom.ObtenerListado();
        }
    }
}
