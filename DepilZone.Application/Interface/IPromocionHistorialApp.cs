using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPreferenteHistorialApp
    {

        Task<List<PreferenteHistorialDTO>> Obtener(int idPreferente);
    }
}
