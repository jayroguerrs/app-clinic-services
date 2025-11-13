using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface ITipoMedicionDat
    {
        Task<List<TipoMedicionDTO>> Listar();
    }
}
