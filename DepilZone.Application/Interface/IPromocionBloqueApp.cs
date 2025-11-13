using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPromocionBloqueApp
    {
        Task<Respuesta<PromocionBloqueEnt>> Insertar(PromocionBloqueEnt model);
        Task<IEnumerable<PromocionBloqueEnt>> ObtenerByIdPromocion(int IdPromocion);
        Task<IEnumerable<PromocionBloqueEnt>> GrabarPlantillas(IList<PromocionBloqueEnt> promocionBloques);
    }
}
