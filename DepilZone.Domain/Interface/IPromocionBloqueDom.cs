using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IPromocionBloqueDom
    {
        Task<Respuesta<PromocionBloqueEnt>> Insertar(PromocionBloqueEnt model);
        Task<IEnumerable<PromocionBloqueEnt>> ObtenerByIdPromocion(int IdPromocion);
        Task<IEnumerable<PromocionBloqueEnt>> GrabarPlantillas(IList<PromocionBloqueEnt> promocionBloques);

    }
}
