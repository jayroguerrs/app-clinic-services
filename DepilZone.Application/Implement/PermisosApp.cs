using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PermisosApp : IPermisosApp
    {
        private readonly IPermisosDom _IPermisosDom;
        public PermisosApp(IPermisosDom IPermisosDom)
        {
            this._IPermisosDom = IPermisosDom;
        }

        public async Task<IEnumerable<ResponsePermisoDTO>> ObtenerPermisosPorId(int id, string permiso)
        {
            return await _IPermisosDom.ObtenerPermisosPorId(id, permiso);
        }
    }
}
