using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class MenuApp: IMenuApp
    {
        private readonly IMenuDom _IMenuDom;
        public MenuApp(IMenuDom IMenuDom)
        {
            this._IMenuDom = IMenuDom;
        }

        public async Task<IEnumerable<MenuDTO>> ObtenerParaMenu(int idUsuario)
        {
            return await _IMenuDom.ObtenerParaMenu(idUsuario);
        }
    }
}
