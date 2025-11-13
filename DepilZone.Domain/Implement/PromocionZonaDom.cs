using DepilZone.Data.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Domain.Implement
{
    public class PromocionZonaDom : IPromocionZonaDom
    {
        private readonly IPromocionZonaDat _IPromocionZonaDat;
        public PromocionZonaDom(IPromocionZonaDat IPromocionZonaDat)
        {
            this._IPromocionZonaDat = IPromocionZonaDat;
        }

        public async Task<IEnumerable<PromocionZonaDTO>> Obtener(int IdPromocion, int IdGenero)
        {
            return await this._IPromocionZonaDat.Obtener(IdPromocion, IdGenero);
        }

        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByServicio(int idServicio, int IdPromocion, int IdGenero)
        {
            return await this._IPromocionZonaDat.ObtenerByServicio(idServicio, IdPromocion, IdGenero);
        }
        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByIdsZonasCorporales(string idsZonasCorporales)
        {
            return await _IPromocionZonaDat.ObtenerByIdsZonasCorporales(idsZonasCorporales);
        }
        public async Task<Respuesta<PromocionZonaEnt>> DeleteById(int IdPromocionZona)
        {
            return await _IPromocionZonaDat.DeleteById(IdPromocionZona);
        }

        public async Task<Respuesta<PromocionZonaDTO>> Insertar(PromocionZonaEnt model)
        {
            return await _IPromocionZonaDat.Insertar(model);
        }

        public async Task<Respuesta<PromocionZonaEnt>> ModificarPrecioBase(PromocionZonaEnt model) {
            return await this._IPromocionZonaDat.ModificarPrecioBase(model);
        }

        public async Task<List<PromocionZonaDTO>> ListarByZona(int idZona)
        {
            return await this._IPromocionZonaDat.ListarByZona(idZona);
        }

        public async Task<List<int>> DeleteByIds(string ids)
        {
            return await _IPromocionZonaDat.DeleteByIds(ids);
        }
    }
}
