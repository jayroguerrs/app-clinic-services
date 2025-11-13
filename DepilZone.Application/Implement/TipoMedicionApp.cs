using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class TipoMedicionApp: ITipoMedicionApp
    {
        private readonly ITipoMedicionDom _ITipoMedicionDom;
        public TipoMedicionApp(ITipoMedicionDom ITipoMedicionDom)
        {
            this._ITipoMedicionDom = ITipoMedicionDom;
        }

        public async Task<List<TipoMedicionDTO>> Listar()
        {
            return await _ITipoMedicionDom.Listar();
        }
    }
}
