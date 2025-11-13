using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ZonaTratamientoApp: IZonaTratamientoApp
    {
        private readonly IZonaTratamientoDom _IZonaTratamientoDom;
        public ZonaTratamientoApp(IZonaTratamientoDom IZonaDom)
        {
            this._IZonaTratamientoDom = IZonaDom;
        }

        public async Task<List<ZonaTratamientoDTO>> Obtener(int idUsuario)
        {
            return await _IZonaTratamientoDom.Obtener(idUsuario);
        }
        public async Task<List<ZonaTratamientoDTO>> ObtenerListadoByServicio(int idServicio, int idUsuario)
        {
            return await _IZonaTratamientoDom.ObtenerListadoByServicio(idServicio, idUsuario);
        }
        public async Task<bool> Insertar(ZonaTratamientoDTO model)
        {
            return await _IZonaTratamientoDom.Insertar(model);
        }
        public async Task<bool> Modificar(ZonaTratamientoDTO model)
        {
            return await _IZonaTratamientoDom.Modificar(model);
        }
 

    }
}
