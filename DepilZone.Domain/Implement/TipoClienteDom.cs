using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
	public class TipoClienteDom : ITipoClienteDom
	{
        private readonly ITipoClienteDat _ITipoClienteDat;
        public TipoClienteDom(ITipoClienteDat ITipoClienteDat)
        {
            this._ITipoClienteDat = ITipoClienteDat;
        }
        public async Task<IEnumerable<TipoClienteEnt>> Obtener()
        {
            return await _ITipoClienteDat.Obtener();
        }
    }
}
