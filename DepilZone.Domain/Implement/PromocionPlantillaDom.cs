using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DepilZone.Data;
using DepilZone.Data.Interface;
using DepilZone.Entidad;

namespace DepilZone.Domain
{
    public class PromocionPlantillaDom : IPromocionPlantillaDom
    {
        private readonly IPromocionPlantillaDat _IPromocionPlantillaDat;
        public PromocionPlantillaDom(IPromocionPlantillaDat IPromocionPlantillaDat)
        {
            this._IPromocionPlantillaDat = IPromocionPlantillaDat;
        }
        public async Task<IEnumerable<PromocionPlantillaEnt>> Obtener()
        {
            return await _IPromocionPlantillaDat.Obtener();
        }
        public async Task<Respuesta<PromocionPlantillaEnt>> Insertar(PromocionPlantillaEnt model)
        {
            return await _IPromocionPlantillaDat.Insertar(model);
        }
        public async Task<Respuesta<PromocionPlantillaEnt>> Modificar(PromocionPlantillaEnt model)
        {
            return await _IPromocionPlantillaDat.Modificar(model);
        }
        public async Task<PromocionPlantillaEnt> ObtenerByIdPlantillaPromocion(int IdPromocion)
        {
            return await _IPromocionPlantillaDat.ObtenerByIdPlantillaPromocion(IdPromocion);
        }
        public async Task<IEnumerable<PromocionPlantillaEnt>> ObtenerByLikeAlias(string Alias)
        {
            return await _IPromocionPlantillaDat.ObtenerByLikeAlias(Alias);
        }
    }
}
