using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IGeneroDat
    {
        Task<IEnumerable<GeneroEnt>> Obtener();
    }
}
