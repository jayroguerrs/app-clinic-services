using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IMenuDat
    {
        Task<IEnumerable<MenuDTO>> ObtenerParaMenu(int idUsuario);
    }
}
