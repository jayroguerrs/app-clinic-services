using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class TipoMedicionDom : ITipoMedicionDom
    {
        private readonly ITipoMedicionDat _ITipoMedicionDat;
        public TipoMedicionDom(ITipoMedicionDat ITipoMedicionDat)
        {
            this._ITipoMedicionDat = ITipoMedicionDat;
        }
        public async Task<List<TipoMedicionDTO>> Listar()
        {
            return await _ITipoMedicionDat.Listar();
        }
    }
}
