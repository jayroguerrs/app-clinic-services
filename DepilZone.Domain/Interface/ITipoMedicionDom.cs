using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface ITipoMedicionDom
    {
        Task<List<TipoMedicionDTO>> Listar();
    }
}
