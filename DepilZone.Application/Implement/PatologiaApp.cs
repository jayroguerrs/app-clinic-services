using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PatologiaApp: IPatologiaApp
    {
        private readonly IPatologiaDom _IPatologiaDom;
        public PatologiaApp(IPatologiaDom IPatologiaDom)
        {
            this._IPatologiaDom = IPatologiaDom;
        }

        public async Task<IEnumerable<PatologiaEnt>> ObtenerListado()
        {
            return await _IPatologiaDom.ObtenerListado();
        }

    }
}
