using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPerfilApp
    {
        Task<IEnumerable<PerfilEnt>> Obtener();
        Task<PerfilConfiguracionDTO> ObtenerById(int idPerfil);
        Task<Respuesta<PerfilEnt>> Insertar(PerfilDTO datos);
        Task<Respuesta<PerfilEnt>> Modificar(PerfilDTO datos);

    }
}
