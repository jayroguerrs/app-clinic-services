using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPromocionPlantillaDat
    {
        Task<IEnumerable<PromocionPlantillaEnt>> Obtener();
        Task<Respuesta<PromocionPlantillaEnt>> Insertar(PromocionPlantillaEnt model);
        Task<Respuesta<PromocionPlantillaEnt>> Modificar(PromocionPlantillaEnt model);
        Task<PromocionPlantillaEnt> ObtenerByIdPlantillaPromocion(int IdPromocion);
        Task<IEnumerable<PromocionPlantillaEnt>> ObtenerByLikeAlias(string Alias);
    }
}
