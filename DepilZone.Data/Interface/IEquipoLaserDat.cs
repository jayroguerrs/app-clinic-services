using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IEquipoLaserDat
    {
        Task<IEnumerable<EquipoLaserEnt>> Obtener();
    }
}
