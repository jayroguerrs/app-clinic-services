using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IMenuDom
    {
        Task<IEnumerable<MenuDTO>> ObtenerParaMenu(int idUsuario);
    }
}
