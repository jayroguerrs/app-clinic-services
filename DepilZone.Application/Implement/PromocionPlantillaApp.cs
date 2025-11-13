using DepilZone.Application.Interface;
using DepilZone.Data.Interface;
using DepilZone.Entidad;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PromocionPlantillaApp : IPromocionPlantillaApp
    {
        private readonly IPromocionPlantillaDom _IPromocionPlantillaDom;

        public PromocionPlantillaApp(IPromocionPlantillaDom IPromocionPlantillaDom)
        {
            this._IPromocionPlantillaDom = IPromocionPlantillaDom;
        }

        public async Task<IEnumerable<PromocionPlantillaEnt>> Obtener()
        {
            return await _IPromocionPlantillaDom.Obtener();
        }
        public async Task<PromocionPlantillaEnt> ObtenerByIdPlantillaPromocion(int IdPromocion)
        {
            return await _IPromocionPlantillaDom.ObtenerByIdPlantillaPromocion(IdPromocion);
        }
        public async Task<IEnumerable<PromocionPlantillaEnt>> ObtenerByLikeAlias(string Alias)
        {
            return await _IPromocionPlantillaDom.ObtenerByLikeAlias(Alias);
        }
        public async Task<Respuesta<PromocionPlantillaEnt>> Insertar(PromocionPlantillaEnt model)
        {
            return await _IPromocionPlantillaDom.Insertar(model);
        }
        public async Task<Respuesta<PromocionPlantillaEnt>> Modificar(PromocionPlantillaEnt model)
        {
            return await _IPromocionPlantillaDom.Modificar(model);
        }
    }
}
