
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IZonaTratamientoDat
    {

        Task<List<ZonaTratamientoDTO>> Obtener(int idUsuario);
        Task<List<ZonaTratamientoDTO>> ObtenerListadoByServicio(int idServicio, int idUsuario);
        Task<bool> Insertar(ZonaTratamientoDTO model);
        Task<bool> Modificar(ZonaTratamientoDTO model);
    }
}
