using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ILibroReclamacionDat
    {
        Task<Respuesta<LibroReclamacionDTO>> Insertar(LibroReclamacionEnt model);
        Task<Respuesta<string>> ObtenerPlantilla(int idTabla);
    }
}
