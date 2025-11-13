using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface ILibroReclamacionApp
    {
        Task<Respuesta<LibroReclamacionDTO>> Insertar(LibroReclamacionEnt model);
        Task<Respuesta<string>> ObtenerPlantilla(int idTabla);
    }
}
