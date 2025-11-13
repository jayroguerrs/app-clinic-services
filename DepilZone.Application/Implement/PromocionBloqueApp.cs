using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PromocionBloqueApp: IPromocionBloqueApp
    {
        private readonly IPromocionBloqueDom _IPromocionBloqueDom;
        public PromocionBloqueApp(IPromocionBloqueDom IPromocionBloqueDom)
        {
            this._IPromocionBloqueDom = IPromocionBloqueDom;
        }
        public async Task<Respuesta<PromocionBloqueEnt>> Insertar(PromocionBloqueEnt model)
        {
            return await _IPromocionBloqueDom.Insertar(model);
        }
        public async Task<IEnumerable<PromocionBloqueEnt>> ObtenerByIdPromocion(int IdPromocion)
        {
            return await _IPromocionBloqueDom.ObtenerByIdPromocion(IdPromocion);
        }
        public async Task<IEnumerable<PromocionBloqueEnt>> GrabarPlantillas(IList<PromocionBloqueEnt> promocionBloques)
        {
            return await _IPromocionBloqueDom.GrabarPlantillas(promocionBloques);
        }

    }

}
