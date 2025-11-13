using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IAlternativaMedicionDom
    {
        Task<List<AlternativaMedicionDTO>> ListarByTipo(int tipo);
    }
}
