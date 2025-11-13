using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IComentarioDat
    {
        Task<IEnumerable<ComentarioEnt>> Obtener();
    }
}
