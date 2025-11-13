using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IMenuApp
    {
        Task<IEnumerable<MenuDTO>> ObtenerParaMenu(int idUsuario);
    }
}
