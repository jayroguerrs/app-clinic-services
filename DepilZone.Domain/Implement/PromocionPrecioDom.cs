using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PromocionPrecioDom: IPromocionPrecioDom
    {
        private readonly IPromocionPrecioDat _IProgramacionPrecioDat;
        public PromocionPrecioDom(IPromocionPrecioDat IProgramacionPrecioDat)
        {
            this._IProgramacionPrecioDat = IProgramacionPrecioDat;
        }

        public async Task<Respuesta<PromocionPrecioEnt>> Insertar(PromocionPrecioEnt model)
        {
            return await _IProgramacionPrecioDat.Insertar(model);
        }

        public async Task<IEnumerable<PromocionPrecioEnt>> ObtenerByIdPromocion(int IdPromocion)
        {
            return await _IProgramacionPrecioDat.ObtenerByIdPromocion(IdPromocion);
        }
        public async Task<IEnumerable<PrecioZonaPromocion>> Obtenerpreciosesionpromocion(int idzona, int sesiones, int idpromocion)
        {
            return await _IProgramacionPrecioDat.Obtenerpreciosesionpromocion(idzona, sesiones, idpromocion);
        }
        public async Task<Respuesta<PromocionPrecioEnt>> DeleteById(int IdPromocionPrecio)
        {
            return await _IProgramacionPrecioDat.DeleteById(IdPromocionPrecio);
        }



    }
}
