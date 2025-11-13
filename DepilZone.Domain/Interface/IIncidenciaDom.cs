using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IIncidenciaDom
    {
        Task<Respuesta<IncidenciaEnt>> Insertar(IncidenciaEnt model);
        Task<IncidenciaEnt> ObtenerById(int id);
        Task<Respuesta<IncidenciaEnt>> Modificar(IncidenciaEnt model);
        Task<IEnumerable<IncidenciaListadoGrillaDTO>> ObtenerListado(int idEstado);
        Task<IncidenciaNivelAtencion> NivelAtencion();
    }
}
