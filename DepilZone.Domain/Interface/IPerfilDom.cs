using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IPerfilDom
    {
        Task<IEnumerable<PerfilEnt>> Obtener();
        Task<PerfilConfiguracionDTO> ObtenerById(int idPerfil);
        Task<Respuesta<PerfilEnt>> Insertar(PerfilDTO perfil);
        Task<Respuesta<PerfilEnt>> Modificar(PerfilDTO perfil);
    }
}
