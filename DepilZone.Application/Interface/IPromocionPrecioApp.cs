using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Interface
{
    public interface IPromocionPrecioApp
    {
        Task<Respuesta<PromocionPrecioEnt>> Insertar(PromocionPrecioEnt model);
        Task<IEnumerable<PromocionPrecioEnt>> ObtenerByIdPromocion(int idPromocion);
        Task<IEnumerable<PrecioZonaPromocion>> Obtenerpreciosesionpromocion(int idzona, int sesiones, int idpromocion);
        Task<Respuesta<PromocionPrecioEnt>> DeleteById(int IdPromocionPrecio);

    }
}
