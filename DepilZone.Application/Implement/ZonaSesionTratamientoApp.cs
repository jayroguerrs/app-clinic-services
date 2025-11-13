using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class ZonaSesionTratamientoApp: IZonaSesionTratamientoApp
    {
        private readonly IZonaSesionTratamientoDom _IZonaSesionTratamientoDom;
        public ZonaSesionTratamientoApp(IZonaSesionTratamientoDom IZonaDom)
        {
            this._IZonaSesionTratamientoDom = IZonaDom;
        }

        public async Task<List<ZonaSesionTratamientoDTO>> ObtenerByZona(int idZona, int idUsuario)
        {
            return await _IZonaSesionTratamientoDom.ObtenerByZona(idZona, idUsuario);
        }
        public async Task<List<ZonaTratamientoDTO>> ObtenerByZonaSesion(int idZona, int idUsuario, int sesion)
        {
            return await _IZonaSesionTratamientoDom.ObtenerByZonaSesion(idZona, idUsuario, sesion);
        }
        public async Task<bool> Insertar(ZonaSesionTratamientosDTO model)
        {
            return await _IZonaSesionTratamientoDom.Insertar(model);
        }
 

    }
}
