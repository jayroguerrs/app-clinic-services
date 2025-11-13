using System.Collections.Generic;
using System.Threading.Tasks;
using DepilZone.Data.Interface;
using DepilZone.Entidad.DTO;

namespace DepilZone.Domain
{
    public class ZonaTratamientoDom : IZonaTratamientoDom
    {
        private readonly IZonaTratamientoDat _IZonaTratamientoDat;
        public ZonaTratamientoDom(IZonaTratamientoDat IUsuarioDat)
        {
            this._IZonaTratamientoDat = IUsuarioDat;
        }

        public async Task<List<ZonaTratamientoDTO>> Obtener(int IdUsuario)
        {
            return await _IZonaTratamientoDat.Obtener(IdUsuario);
        }
        public async Task<List<ZonaTratamientoDTO>> ObtenerListadoByServicio(int idServicio, int IdUsuario)
        {
            return await _IZonaTratamientoDat.ObtenerListadoByServicio(idServicio, IdUsuario);
        }
        public async Task<bool> Insertar(ZonaTratamientoDTO model)
        {
            return await _IZonaTratamientoDat.Insertar(model);
        }
        public async Task<bool> Modificar(ZonaTratamientoDTO model)
        {
            return await _IZonaTratamientoDat.Modificar(model);
        }

    }
}
