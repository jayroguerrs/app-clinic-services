using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DepilZone.Application.Interface
{
    public interface IZonaSesionTratamientoApp
    {
        Task<List<ZonaSesionTratamientoDTO>> ObtenerByZona(int idZona, int idUsuario);
        Task<List<ZonaTratamientoDTO>> ObtenerByZonaSesion(int idZona, int idUsuario, int sesion);
        Task<bool> Insertar(ZonaSesionTratamientosDTO model);

    }
}
