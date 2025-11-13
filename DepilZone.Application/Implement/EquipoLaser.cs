using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class EquipoLaserApp : IEquipoLaserApp
    {
        private readonly IEquipoLaserDom _IEquipoLaserDom;
        public EquipoLaserApp(IEquipoLaserDom IEquipoLaserDom)
        {
            _IEquipoLaserDom = IEquipoLaserDom;
        }
        public async Task<IEnumerable<EquipoLaserEnt>> Obtener()
        {
            return await _IEquipoLaserDom.Obtener();
        }
    }
}
