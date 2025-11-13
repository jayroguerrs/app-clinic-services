using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPreferenteHistorialDat
    {
        Task<List<PreferenteHistorialDTO>> Obtener(int idPreferente);

    }
}
