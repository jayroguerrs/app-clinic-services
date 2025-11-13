using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
   public interface IPermisosDat
    {
        Task<IEnumerable<ResponsePermisoDTO>> ObtenerPermisosPorId(int id, string permiso);
    }
}
