using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PromocionBloqueDom: IPromocionBloqueDom
    {
        private readonly IPromocionBloqueDat _IPromocionBloqueDat;
        public PromocionBloqueDom(IPromocionBloqueDat IPromocionBloqueDat)
        {
            this._IPromocionBloqueDat = IPromocionBloqueDat;
        }
        public async Task<Respuesta<PromocionBloqueEnt>> Insertar(PromocionBloqueEnt model)
        {
            return await _IPromocionBloqueDat.Insertar(model);
        }

        public async Task<IEnumerable<PromocionBloqueEnt>> ObtenerByIdPromocion(int IdPromocion)
        {
            return await _IPromocionBloqueDat.ObtenerByIdPromocion(IdPromocion);
        }
        public async Task<IEnumerable<PromocionBloqueEnt>> GrabarPlantillas(IList<PromocionBloqueEnt> promocionBloques)
        {
            return await _IPromocionBloqueDat.GrabarPlantillas(promocionBloques);
        }
       
  

    }
}
