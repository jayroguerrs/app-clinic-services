using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Data.Interface
{
    public interface IPromocionPrecioDat
    {

        Task<Respuesta<PromocionPrecioEnt>> Insertar(PromocionPrecioEnt model);
        Task<IEnumerable<PromocionPrecioEnt>> ObtenerByIdPromocion(int IdPromocion);
        Task<IEnumerable<PrecioZonaPromocion>> Obtenerpreciosesionpromocion(int idzona, int sesiones, int idpromocion);
        Task<Respuesta<PromocionPrecioEnt>> DeleteById(int IdPromocionPrecio);


    }
}
