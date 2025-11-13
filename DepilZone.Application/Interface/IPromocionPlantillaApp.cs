using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPromocionPlantillaApp
    {
        Task<IEnumerable<PromocionPlantillaEnt>> Obtener();
        Task<Respuesta<PromocionPlantillaEnt>> Insertar(PromocionPlantillaEnt model);
        Task<PromocionPlantillaEnt> ObtenerByIdPlantillaPromocion(int IdPromocion);
        Task<IEnumerable<PromocionPlantillaEnt>> ObtenerByLikeAlias(string Alias);
        Task<Respuesta<PromocionPlantillaEnt>> Modificar(PromocionPlantillaEnt model);
    }
}
