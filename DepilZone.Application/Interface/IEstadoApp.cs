using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IEstadoApp
    {
        Task<IEnumerable<EstadoEnt>> Obtener();
        Task<IEnumerable<EstadoEnt>> ObtenerByEntidad(string entidad);
        Task<IEnumerable<EstadoEnt>> selStateByFather(string entidad, int idEstPadr);
    }
}
