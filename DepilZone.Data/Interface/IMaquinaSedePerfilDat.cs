using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IMaquinaSedePerfilDat
    {
        Task<bool> Insertar(MaquinaSedePerfilDTO model);
        Task<List<MaquinaSedePerfilDTO>> ObtenerByMaquinaSede(int idUsuario, int idMaquinaSede);
    }
}
