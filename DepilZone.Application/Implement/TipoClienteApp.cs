using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
	public class TipoClienteApp : ITipoClienteApp
	{
        private readonly ITipoClienteDom _ITipoClienteDom;
        public TipoClienteApp(ITipoClienteDom ITipoClienteDom)
        {
            this._ITipoClienteDom = ITipoClienteDom;
        }
        public async Task<IEnumerable<TipoClienteEnt>> Obtener()
        {
            return await _ITipoClienteDom.Obtener();
        }
    }
}
