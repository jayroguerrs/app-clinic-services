using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PermisosDom : IPermisosDom
    {
        private readonly IPermisosDat _IPermisosDat;
        public PermisosDom(IPermisosDat IPermisosDat)
        {
            this._IPermisosDat = IPermisosDat;
        }
        public async Task<IEnumerable<ResponsePermisoDTO>> ObtenerPermisosPorId(int id, string permiso)
        {
            return await _IPermisosDat.ObtenerPermisosPorId(id, permiso);
        }

    }
}
