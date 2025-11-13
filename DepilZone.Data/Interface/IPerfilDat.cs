using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPerfilDat
    {
        Task<IEnumerable<PerfilEnt>> Obtener();
        Task<PerfilConfiguracionDTO> ObtenerById(int idPerfil);
        Task<Respuesta<PerfilEnt>> Insertar(PerfilDTO perfil);
        Task<Respuesta<PerfilEnt>> Modificar(PerfilDTO perfil);

    }
}
