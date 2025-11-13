using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class ZonaSesionTratamientoDom : IZonaSesionTratamientoDom
    {
        private readonly IZonaSesionTratamientoDat _IZonaSesionTratamientoDat;
        public ZonaSesionTratamientoDom(IZonaSesionTratamientoDat IUsuarioDat)
        {
            this._IZonaSesionTratamientoDat = IUsuarioDat;
        }

        public async Task<List<ZonaSesionTratamientoDTO>> ObtenerByZona(int idZona, int idUsuario)
        {
            return await _IZonaSesionTratamientoDat.ObtenerByZona(idZona, idUsuario);
        }
        public async Task<List<ZonaTratamientoDTO>> ObtenerByZonaSesion(int idZona, int idUsuario, int sesion)
        {
            return await _IZonaSesionTratamientoDat.ObtenerByZonaSesion(idZona, idUsuario, sesion);
        }
        public async Task<bool> Insertar(ZonaSesionTratamientosDTO model)
        {
            return await _IZonaSesionTratamientoDat.Insertar(model);
        }

    }
}
