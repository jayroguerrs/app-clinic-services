using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPromocionBloqueDat
    {
        Task<Respuesta<PromocionBloqueEnt>> Insertar(PromocionBloqueEnt model);
        Task<IEnumerable<PromocionBloqueEnt>> ObtenerByIdPromocion(int IdPromocion);
        Task<IEnumerable<PromocionBloqueEnt>> GrabarPlantillas(IList<PromocionBloqueEnt> promocionBloques);
    }
}
