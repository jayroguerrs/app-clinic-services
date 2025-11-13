using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPromocionPlantillaDom
    {
        Task<IEnumerable<PromocionPlantillaEnt>> Obtener();
        Task<PromocionPlantillaEnt> ObtenerByIdPlantillaPromocion(int IdPromocion);
        Task<Respuesta<PromocionPlantillaEnt>> Insertar(PromocionPlantillaEnt model);
        Task<Respuesta<PromocionPlantillaEnt>> Modificar(PromocionPlantillaEnt model);
        Task<IEnumerable<PromocionPlantillaEnt>> ObtenerByLikeAlias(string Alias);
    }
}
