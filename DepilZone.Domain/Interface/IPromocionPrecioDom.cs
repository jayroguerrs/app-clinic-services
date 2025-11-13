
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Interface
{
    public interface IPromocionPrecioDom
    {
        Task<Respuesta<PromocionPrecioEnt>> Insertar(PromocionPrecioEnt model);
        Task<IEnumerable<PromocionPrecioEnt>> ObtenerByIdPromocion(int IdPromocion);
        Task<IEnumerable<PrecioZonaPromocion>> Obtenerpreciosesionpromocion(int idzona, int sesiones, int idpromocion);
        Task<Respuesta<PromocionPrecioEnt>> DeleteById(int IdPromocionPrecio);


    }

}
