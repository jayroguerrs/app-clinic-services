using DepilZone.Application.Interface;
using DepilZone.Domain.Interface;
using DepilZone.Entidad;
using DepilZone.Entidad.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepilZone.Application.Implement
{
    public class PromocionCategoriaApp: IPromocionCategoriaApp
    {
        private readonly IPromocionCategoriaDom _IPromocionCategoriaDom;
        public PromocionCategoriaApp(IPromocionCategoriaDom IPromocionCategoriaDom)
        {
            this._IPromocionCategoriaDom = IPromocionCategoriaDom;
        }

        public async Task<List<PromocionCategoriaDTO>> Listar()
        {
            return await _IPromocionCategoriaDom.Listar();
        }
        public async Task<bool> Registrar(PromocionCategoriaDTO model)
        {
            return await _IPromocionCategoriaDom.Registrar(model);
        }
        public async Task<bool> Modificar(int id, PromocionCategoriaDTO model)
        {
            return await _IPromocionCategoriaDom.Modificar(id, model);
        }

    }
}
