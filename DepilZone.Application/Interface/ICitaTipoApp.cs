using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DepilZone.Application.Interface
{
    public interface ICitaTipoApp
    {
        Task<IEnumerable<CitaTipoEnt>> Obtener();
        Task<Respuesta<CitaTipoEnt>> Insertar(CitaTipoEnt model);
        Task<CitaTipoEnt> ObtenerById(int IdTipoCita);
        Task<IEnumerable<CitaTipoEnt>> ObtenerByLikeNombre(string Descripcion);
        Task<Respuesta<CitaTipoEnt>> Modificar(CitaTipoEnt model);
    }
}
