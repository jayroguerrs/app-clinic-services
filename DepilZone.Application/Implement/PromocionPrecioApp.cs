using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PromocionPrecioApp: IPromocionPrecioApp
    {

        private readonly IPromocionPrecioDom _IProgramacionPrecioDom;
        public PromocionPrecioApp(IPromocionPrecioDom IProgramacionPrecioDom)
        {
            this._IProgramacionPrecioDom = IProgramacionPrecioDom;
        }

        public async Task<Respuesta<PromocionPrecioEnt>> Insertar(PromocionPrecioEnt model)
        {
            return await _IProgramacionPrecioDom.Insertar(model);
        }

        public async Task<IEnumerable<PromocionPrecioEnt>> ObtenerByIdPromocion(int idPromocion)
        {
            return await _IProgramacionPrecioDom.ObtenerByIdPromocion(idPromocion);
        }
        public async Task<IEnumerable<PrecioZonaPromocion>> Obtenerpreciosesionpromocion(int idzona, int sesiones, int idpromocion)
        {
            return await _IProgramacionPrecioDom.Obtenerpreciosesionpromocion(idzona,sesiones,idpromocion);
        }

        public async Task<Respuesta<PromocionPrecioEnt>> DeleteById(int IdPromocionPrecio)
        {
            return await _IProgramacionPrecioDom.DeleteById(IdPromocionPrecio);
        }

    }

}
