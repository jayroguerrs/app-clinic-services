using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPromocionZonaApp
    {
        
        Task<IEnumerable<PromocionZonaDTO>> Obtener(int IdPromocion, int idGenero);
        Task<IEnumerable<PromocionZonaDTO>> ObtenerByServicio(int idServicio, int IdPromocion, int idGenero);
        Task<IEnumerable<PromocionZonaDTO>> ObtenerByIdsZonasCorporales(string idsZonasCorporales);
        Task<Respuesta<PromocionZonaEnt>> ModificarPrecioBase(PromocionZonaEnt model);
        Task<Respuesta<PromocionZonaEnt>> DeleteById(int IdPromocionZona);
        Task<Respuesta<PromocionZonaDTO>> Insertar(PromocionZonaEnt model);

        Task<List<PromocionZonaDTO>> ListarByZona(int idZona);

        Task<List<int>> DeleteByIds(string ids);

    }

}
