using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IAlternativaMedicionApp
    {
        Task<List<AlternativaMedicionDTO>> ListarByTipo(int tipo);
    }
}
