using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPermisosApp
    {
        Task<IEnumerable<ResponsePermisoDTO>> ObtenerPermisosPorId(int id, string permiso);

    }
}
