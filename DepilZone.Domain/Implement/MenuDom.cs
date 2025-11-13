using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class MenuDom : IMenuDom
    {
        private readonly IMenuDat _IMenuDat;
        public MenuDom(IMenuDat IMenuDat)
        {
            this._IMenuDat = IMenuDat;
        }
        public async Task<IEnumerable<MenuDTO>> ObtenerParaMenu(int idUsuario)
        {
            return await _IMenuDat.ObtenerParaMenu(idUsuario);
        }
    }
}
