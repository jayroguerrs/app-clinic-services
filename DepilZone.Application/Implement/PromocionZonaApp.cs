using DepilZone.Application.Interface;
using DepilZone.Domain.Implement;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PromocionZonaApp: IPromocionZonaApp
    {
        private readonly IPromocionZonaDom _IPromocionZonaDom;
        public PromocionZonaApp(IPromocionZonaDom IPromocionZonaDom)
        {
            this._IPromocionZonaDom = IPromocionZonaDom;
        }
        public async Task<IEnumerable<PromocionZonaDTO>> Obtener(int IdPromocion, int IdGenero)
        {
            return await _IPromocionZonaDom.Obtener(IdPromocion, IdGenero);
        }

        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByServicio(int idServicio, int IdPromocion, int IdGenero)
        {
            return await _IPromocionZonaDom.ObtenerByServicio(idServicio, IdPromocion, IdGenero);
        }

        public async Task<IEnumerable<PromocionZonaDTO>> ObtenerByIdsZonasCorporales(string idsZonasCorporales)
        {
            return await _IPromocionZonaDom.ObtenerByIdsZonasCorporales(idsZonasCorporales);
        }
        public async Task<Respuesta<PromocionZonaEnt>> ModificarPrecioBase(PromocionZonaEnt model)
        {
            return await this._IPromocionZonaDom.ModificarPrecioBase(model);
        }
        public async Task<Respuesta<PromocionZonaDTO>> Insertar(PromocionZonaEnt model)
        {
            return await this._IPromocionZonaDom.Insertar(model);
        }
        public async Task<Respuesta<PromocionZonaEnt>> DeleteById(int IdPromocionZona)
        {
            return await this._IPromocionZonaDom.DeleteById(IdPromocionZona);
        }

        public async Task<List<PromocionZonaDTO>> ListarByZona(int idZona)
        {
            return await this._IPromocionZonaDom.ListarByZona(idZona);
        }

        public async Task<List<int>> DeleteByIds(string ids)
        {
            return await _IPromocionZonaDom.DeleteByIds(ids);
        }
    }
}
